import { CommonModule } from '@angular/common';
import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Subject, takeUntil } from 'rxjs';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';

import { ServicioService } from '../../shared/Service/servicio/servicio.service';
import { Servicio } from '../../shared/interfaces/servicio.interface';
import { FormularioServicioComponent } from './component/formulario-servicio/formulario-servicio.component';

@Component({
  selector: 'app-servicio',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    ConfirmDialogModule,
    InputTextModule
  ],
  providers: [
    DialogService,
    ConfirmationService,
    MessageService
  ],
  templateUrl: './servicio.component.html',
  styleUrls: ['./servicio.component.scss']
})
export class ServicioComponent implements OnInit, OnDestroy {
  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;

  infoTable: Servicio[] = [];
  serviciosDesactivados: Servicio[] = [];
  private allInfoTable: Servicio[] = [];
  private allServiciosDesactivados: Servicio[] = [];

  loading = true;
  ref!: DynamicDialogRef | null;
  nombreFiltro = '';

  toggleActive = true;
  toggleInactive = true;
  rowsActive = 10;
  rowsInactive = 5;

  private readonly destroy$ = new Subject<void>();

  constructor(
    private readonly service: ServicioService,
    private readonly dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.getInfoTable();
    this.getServiciosDesactivados();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();

    if (this.ref) {
      try { this.ref.close(); } catch {}
      this.ref = null;
    }
  }

  focusBusqueda(): void {
    setTimeout(() => this.searchInput?.nativeElement.focus(), 0);
  }

  getInfoTable(): void {
    this.loading = true;
    this.service.getList()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: Servicio[]) => {
          this.allInfoTable = Array.isArray(response) ? response : [];
          this.applyNombreFilter();
          this.loading = false;
        },
        error: (error) => {
          this.loading = false;
          this.showMessage('error', 'Error', 'No se pudo cargar servicios activos');
          console.error('Error cargando servicios activos:', error);
        }
      });
  }

  getServiciosDesactivados(): void {
    this.service.getDesactivados()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: Servicio[]) => {
          this.allServiciosDesactivados = Array.isArray(response) ? response : [];
          this.applyNombreFilter();
        },
        error: (error) => {
          this.showMessage('error', 'Error', 'No se pudieron cargar servicios desactivados');
          console.error('Error cargando servicios desactivados:', error);
        }
      });
  }

  filtrarServicios(): void {
    this.applyNombreFilter();
  }

  private applyNombreFilter(): void {
    const q = (this.nombreFiltro ?? '').toString().trim().toLowerCase();
    if (!q) {
      this.infoTable = [...this.allInfoTable];
      this.serviciosDesactivados = [...this.allServiciosDesactivados];
      return;
    }

    this.infoTable = this.allInfoTable.filter(s =>
      (s?.nombre ?? '').toString().toLowerCase().includes(q) ||
      (s?.codigo ?? '').toString().toLowerCase().includes(q)
    );

    this.serviciosDesactivados = this.allServiciosDesactivados.filter(s =>
      (s?.nombre ?? '').toString().toLowerCase().includes(q) ||
      (s?.codigo ?? '').toString().toLowerCase().includes(q)
    );
  }

  filterInactive(): void {
    this.toggleInactive = !this.toggleInactive;
  }

  new(): void {
    this.ref = this.dialogService.open(FormularioServicioComponent, {
      data: { action: 'Crear' },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getInfoTable();
      this.getServiciosDesactivados();
    });
  }

  edit(infoComponent: Servicio, event?: Event): void {
    event?.stopPropagation();

    this.ref = this.dialogService.open(FormularioServicioComponent, {
      data: {
        action: 'actualizar',
        servicioId: infoComponent.servicioId,
        codigo: infoComponent.codigo,
        nombre: infoComponent.nombre
      },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getInfoTable();
      this.getServiciosDesactivados();
    });
  }

  confirmDesactivar(servicioId: number, nombre?: string): void {
    this.confirmationService.confirm({
      message: `¿Estás segura que quieres desactivar el servicio "${nombre ?? servicioId}"?`,
      header: 'Confirmar desactivación',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Sí',
      rejectLabel: 'No',
      accept: () => this.desactivar(servicioId),
      reject: () => {}
    });
  }

  desactivar(servicioId: number): void {
    this.service.delete(servicioId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: { mensaje: string }) => {
          this.showMessage('info', 'Servicio', response?.mensaje ?? 'Servicio desactivado');
          setTimeout(() => {
            this.getInfoTable();
            this.getServiciosDesactivados();
          }, 400);
        },
        error: (error) => {
          const mensaje = error?.error?.mensaje || 'Error desactivando el servicio';
          this.showMessage('error', 'Error', mensaje);
          console.error('Error desactivando el servicio:', error);
        }
      });
  }

  confirmReactivar(servicioId: number, nombre?: string): void {
    this.confirmationService.confirm({
      message: `¿Estás segura que quieres reactivar el servicio "${nombre ?? servicioId}"?`,
      header: 'Confirmar reactivación',
      icon: 'pi pi-check-circle',
      acceptLabel: 'Sí',
      rejectLabel: 'No',
      accept: () => this.reactivar(servicioId),
      reject: () => {}
    });
  }

  reactivar(servicioId: number): void {
    this.service.reactivar(servicioId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: { mensaje: string }) => {
          this.showMessage('success', 'Servicio', response?.mensaje ?? 'Servicio reactivado');
          setTimeout(() => {
            this.getInfoTable();
            this.getServiciosDesactivados();
          }, 400);
        },
        error: (error) => {
          const mensaje = error?.error?.mensaje || 'Error reactivando el servicio';
          this.showMessage('error', 'Error', mensaje);
          console.error('Error reactivando el servicio:', error);
        }
      });
  }

  onClose(): void {
    // cerrar diálogo si existe
    try { this.ref?.close(); } catch {}
    this.ref = null;

    // limpiar filtros mínimos requeridos por el template
    this.nombreFiltro = '';
    this.applyNombreFilter();

    // devolver foco a la búsqueda cuando corresponda
    setTimeout(() => this.searchInput?.nativeElement.focus(), 0);
  }

  private showMessage(
    severity: 'success' | 'info' | 'warn' | 'error',
    summary: string,
    detail: string
  ): void {
    this.messageService.add({ severity, summary, detail });
  }
}