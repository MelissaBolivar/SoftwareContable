import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';

import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { TableModule } from 'primeng/table';
import { MessageService } from 'primeng/api';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { DropdownModule } from 'primeng/dropdown';

import { ServicioService } from '../../../../shared/Service/servicio/servicio.service';
import { CreateOrUpdateServicio } from '../../../../shared/interfaces/CreateOrUpdateServicio.interface';
import { Servicio } from '../../../../shared/interfaces/servicio.interface';

@Component({
  selector: 'app-formulario-servicio',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    ButtonModule,
    ConfirmDialogModule,
    ProgressSpinnerModule,
    TableModule,
    DialogModule,
    DropdownModule
  ],
  templateUrl: './formulario-servicio.component.html',
  styleUrls: ['./formulario-servicio.component.scss']
})
export class FormularioServicioComponent implements OnInit, OnDestroy {
  componentForm: FormGroup;
  requiredField = 'Campo obligatorio';
  headerName = '';
  action = '';
  id = '';
  loading = false;
  servicios: Servicio[] = [];
  mostrarDialogoDuplicado = false;

  categorias: { label: string; value: string }[] = [
    { label: 'General', value: 'general' },
    { label: 'Electrónico', value: 'electronico' },
    { label: 'Consumible', value: 'consumible' }
  ];

  private readonly destroy$ = new Subject<void>();

  constructor(
    private readonly formBuilder: FormBuilder,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private readonly service: ServicioService,
    private readonly messageService: MessageService
  ) {
    // --- Ajuste: Validator para que solo acepte números ---
    this.componentForm = this.formBuilder.group({
      codigo: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
      nombre: ['', Validators.required],
      categoria: [null]
    });
  }

  ngOnInit(): void {
    this.action = (this.config.data?.action || '').toString();
    this.headerName = this.config.data?.name || '';
    this.servicios = Array.isArray(this.config.data?.servicios) ? this.config.data.servicios : [];

    if (this.action?.toLowerCase() === 'actualizar') {
      this.id = String(this.config.data?.servicioId ?? '');
      this.componentForm.patchValue({
        codigo: this.config.data?.codigo,
        nombre: this.config.data?.nombre,
        categoria: this.config.data?.categoria ?? null
      });
    }

    this.componentForm.get('codigo')?.valueChanges
      .pipe(takeUntil(this.destroy$))
      .subscribe(() => {
        const ctrl = this.componentForm.get('codigo');
        if (ctrl?.hasError('duplicado')) {
          ctrl.setErrors(null);
        }
        if (this.mostrarDialogoDuplicado) {
          this.mostrarDialogoDuplicado = false;
        }
      });
  }

  onSubmit(): void {
    if (!this.componentForm.valid) {
      this.componentForm.markAllAsTouched();
      return;
    }

    this.loading = true;
    const codigoIngresadoRaw = (this.componentForm.value.codigo || '').toString().trim();
    const codigoNorm = codigoIngresadoRaw.toLowerCase();
    const currentId = this.id || String(this.config.data?.servicioId ?? '');

    const marcarDuplicado = () => {
      const codigoCtrl = this.componentForm.get('codigo');
      codigoCtrl?.setErrors({ duplicado: true });
      codigoCtrl?.markAsTouched();
      codigoCtrl?.markAsDirty();
      this.mostrarDialogoDuplicado = true;
      this.loading = false;
    };

    const toId = (v: any) => {
      if (v == null) return '';
      const n = Number(v);
      return Number.isNaN(n) ? String(v) : String(Math.trunc(n));
    };

    this.service.getList()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (list: Servicio[]) => {
          this.servicios = Array.isArray(list) ? list : [];

          const normalize = (v: any) => (v || '').toString().trim().toLowerCase();

          // Buscar cualquier servicio (activo o inactivo) con el mismo código
          const found = this.servicios.find(p => {
            if (!p) return false;
            return normalize(p.codigo) === codigoNorm;
          });

          const actionLower = (this.action || '').toLowerCase();

          if (actionLower === 'crear') {
            if (found) { marcarDuplicado(); return; }
            const createParser = this.createParserFormData();
            this.service.create(createParser).pipe(takeUntil(this.destroy$)).subscribe({
              next: () => {
                this.loading = false;
                this.showMessage('success', 'Servicio', 'Servicio creado correctamente');
                this.onClose();
              },
              error: (error: any) => { this.loading = false; this.handleBackendError(error); }
            });
            return;
          }

          if (actionLower === 'actualizar') {
            if (found) {
              const foundId = toId((found as any).servicioId ?? (found as any).id ?? '');
              const curId = toId(currentId);
              if (foundId !== '' && curId !== '' && foundId !== curId) {
                marcarDuplicado();
                return;
              }
            }

            const updateParser = this.updateParserFormData();
            this.service.update(updateParser).pipe(takeUntil(this.destroy$)).subscribe({
              next: () => {
                this.loading = false;
                this.showMessage('success', 'Servicio', 'Servicio actualizado correctamente');
                this.onClose();
              },
              error: (error: any) => { this.loading = false; this.handleBackendError(error); }
            });
            return;
          }

          // Fallback: tratar como creación
          if (found) { marcarDuplicado(); return; }
          const createParser = this.createParserFormData();
          this.service.create(createParser).pipe(takeUntil(this.destroy$)).subscribe({
            next: () => {
              this.loading = false;
              this.showMessage('success', 'Servicio', 'Servicio creado correctamente');
              this.onClose();
            },
            error: (error: any) => { this.loading = false; this.handleBackendError(error); }
          });
        },
        error: (err: any) => {
          console.error('Error fetching servicios for duplicate check', err);
          this.loading = false;
          this.showMessage('error', 'Error', 'No se pudo validar el código. Intente de nuevo.');
        }
      });
  }

  onClose(): void {
    this.componentForm.reset();
    this.ref.close();
  }

  private createParserFormData(): CreateOrUpdateServicio {
    return {
      servicioId: null,
      codigo: (this.componentForm.value.codigo || '').toString().trim(),
      nombre: (this.componentForm.value.nombre || '').toString().trim()
    };
  }

  private updateParserFormData(): CreateOrUpdateServicio {
    return {
      servicioId: Number.parseInt(this.id || String(this.config.data?.servicioId ?? '0')),
      codigo: (this.componentForm.value.codigo || '').toString().trim(),
      nombre: (this.componentForm.value.nombre || '').toString().trim()
    };
  }

  private handleBackendError(error: any): void {
    const mensaje = error?.error?.mensaje || 'Algo salió mal, intente de nuevo';

    if (error?.status === 409) {
      const codigoCtrl = this.componentForm.get('codigo');
      codigoCtrl?.setErrors({ duplicado: true });
      codigoCtrl?.markAsTouched();
      codigoCtrl?.markAsDirty();
      this.mostrarDialogoDuplicado = true;
    } else if (error?.status === 400) {
      this.showMessage('error', 'Error de validación', mensaje);
    } else {
      this.showMessage('error', 'Error', mensaje);
    }
  }

  private showMessage(
    severity: 'success' | 'info' | 'warn' | 'error',
    summary: string,
    detail: string
  ): void {
    this.messageService.add({ severity, summary, detail });
  }

  toggleTheme(): void {
    // preserved in case you want theme switching later
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
