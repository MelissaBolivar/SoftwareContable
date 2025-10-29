import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { UserService } from '../../../../shared/Service/user/user.service';
import { InformationUser, TipoIdentificacion } from '../../../../shared/interfaces/InformationUser.interface';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService } from 'primeng/api';
import { RegularExpressions } from '../../../../shared/constant/regex';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { ClienteService } from '../../../../shared/Service/cliente/cliente.service';
import { CreateOrUpdateCliente } from '../../../../shared/interfaces/CreateOrUpdateCliente.interface';

@Component({
  selector: 'app-formulario-clientes',
  standalone: true,
  imports: [
    InputTextModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    CalendarModule,
    ConfirmDialogModule,
    DropdownModule,
    ProgressSpinnerModule
  ],
  templateUrl: './formulario-clientes.component.html',
  styleUrl: './formulario-clientes.component.scss'
})
export class FormularioClientesComponent implements OnInit {
  componentForm: FormGroup;
  requiredField = 'Campo obligatorio';
  headerName = '';
  action = '';
  id = '';
  loading = false;

  possitiveNumberInt = 'Debe ser un número entero positivo';
  possitiveNumberIntGreatZero = 'Debe ser un número mayor o igual a cero';
  possitiveNumberIntGreat2020 = 'Debe ser un número mayor o igual a 2020';
  possitiveNumberIntGreatOne = 'Debe ser un número mayor o igual a uno';
  possitiveNumberIntLessTwelve = 'Debe ser un número menor o igual a doce';

  listUser: TipoIdentificacion[] = [];

  constructor(
    private readonly formBuilder: FormBuilder,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private readonly service: ClienteService,
    private readonly userService: UserService,
    private readonly messageService: MessageService,
  ) {
    this.componentForm = this.formBuilder.group({
      tipoDocumentoId: ['', Validators.required],
      numeroDocumento: ['', [Validators.required, Validators.pattern(RegularExpressions.NUMERIC)]],
      razonSocial: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(120)]],
      direccion: ['', Validators.required],
      telefono: ['', [Validators.required, Validators.pattern(RegularExpressions.NUMERIC)]],
      correo: ['', [Validators.required, Validators.email]],
      // Controles adicionales usados en patchValue desde el diálogo
      month: [''],
      year: [''],
      amount: [''],
      userId: ['']
    });
  }

  ngOnInit() {
    this.loadInformation();

    this.action = this.config?.data?.action ?? '';

    this.headerName = this.config?.data?.name ?? '';

    if (this.action === 'actualizar') {
      this.id = String(this.config?.data?.id ?? '');
      this.componentForm.patchValue({
        month: this.config?.data?.month ?? '',
        year: this.config?.data?.year ?? '',
        amount: this.config?.data?.amount ?? '',
        userId: this.config?.data?.userId ?? '',
        numeroDocumento: this.config?.data?.numeroDoc ?? '',
        tipoDocumentoId: this.config?.data?.tipoDocId !== undefined ? Number(this.config.data.tipoDocId) : '',
        razonSocial: this.config?.data?.razonSocialTercero ?? '',
        direccion: this.config?.data?.direccionTercero ?? '',
        telefono: this.config?.data?.telefonoTercero ?? '',
        correo: this.config?.data?.correoElectronicoTercero ?? ''
      });
    }
  }

  loadInformation() {
    this.getUser();
  }

  getUser() {
    this.loading = true;
    this.userService.getListTiposDocumentos().subscribe({
      next: response => {
        this.loading = false;
        this.listUser = response ?? [];
      },
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    });
  }

  onSubmit() {
    if (!this.componentForm.valid) {
      this.componentForm.markAllAsTouched();
      return;
    }

    this.loading = true;

    if (this.action === 'crear') {
      const createParser = this.createParserFormData();
      this.service.create(createParser).subscribe({
        next: () => {
          this.loading = false;
          this.onClose();
        }, error: (error) => {
          this.loading = false;
          this.showError(error);
        }
      });
    } else {
      const updateParser = this.updateParserFormData();
      this.service.update(updateParser).subscribe({
        next: () => {
          this.loading = false;
          this.onClose();
        }, error: (error) => {
          this.loading = false;
          this.showError(error);
        }
      });
    }
  }

  onClose() {
    this.componentForm.reset();
    this.ref.close();
  }

  private createParserFormData(): CreateOrUpdateCliente {
    return {
      TipoDocId: this.componentForm.value.tipoDocumentoId,
      NumeroDoc: this.componentForm.value.numeroDocumento,
      RazonSocialTercero: this.componentForm.value.razonSocial,
      DireccionTercero: this.componentForm.value.direccion,
      TelefonoTercero: this.componentForm.value.telefono,
      CorreoElectronicoTercero: this.componentForm.value.correo,
      TipoTerceroId: 2
    };
  }

  private updateParserFormData(): CreateOrUpdateCliente {
    return {
      TerceroId: this.id,
      TipoDocId: this.componentForm.value.tipoDocumentoId,
      NumeroDoc: this.componentForm.value.numeroDocumento,
      RazonSocialTercero: this.componentForm.value.razonSocial,
      DireccionTercero: this.componentForm.value.direccion,
      TelefonoTercero: this.componentForm.value.telefono,
      CorreoElectronicoTercero: this.componentForm.value.correo,
      TipoTerceroId: 2
    };
  }

  private showError(error: any): void {
    if (error?.status === 400) {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: error.error?.message ?? 'Error del servidor',
      });
    } else {
      this.showMessage('error', 'Error', 'Algo salió mal, intente de nuevo');
    }
  }

  private showMessage(severity: 'success' | 'info' | 'warning' | 'error', summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }
}