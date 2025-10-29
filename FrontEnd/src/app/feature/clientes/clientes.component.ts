import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { FieldFilter } from '../../shared/interfaces/FieldFilter.interface';
import { ConfirmationService, MessageService } from 'primeng/api';
import { HttpService } from '../../shared/Service/http-service/http.service';
import { UserService } from '../../shared/Service/user/user.service';
import { InputTextModule } from 'primeng/inputtext';
import { FormularioClientesComponent } from './component/formulario-clientes/formulario-clientes.component';
import { ClienteService } from '../../shared/Service/cliente/cliente.service';
import { Cliente } from '../../shared/interfaces/cliente.interface';

@Component({
  selector: 'app-clientes',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    CalendarModule,
    ConfirmDialogModule,
    InputTextModule
  ],
  providers:[
    DialogService,
    ConfirmationService,
    ClienteService,
    HttpService,
    UserService
  ],
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.scss'
})
export class ClientesComponent implements OnInit {
  infoTable!: (Cliente & { tipoDocLabel?: string })[];
  private allInfoTable: (Cliente & { tipoDocLabel?: string })[] = [];
  loading = true;
  ref!: DynamicDialogRef;
  filters: FieldFilter[] = [];

  // Estado de filtro para mostrar activos / inactivos
  showOnlyActive = true;

  // Bindings para buscador
  nombreFiltro = '';
  tipoFiltro = '';

  @ViewChild('searchInput', { static: false }) searchInputRef!: ElementRef<HTMLInputElement>;

  constructor(
    private readonly service: ClienteService,
    public dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService
  ) {}

  ngOnInit() {
    this.getinfoTable();
  }

  getTipoDocLabel(tipoDocId: string | number | { tipoDocId?: number, Nombre?: string } | undefined): string {
    if (tipoDocId === null || tipoDocId === undefined) return '';

    if (typeof tipoDocId === 'object') {
      const obj = tipoDocId as { tipoDocId?: number, Nombre?: string };
      if (obj.Nombre && String(obj.Nombre).trim() !== '') return String(obj.Nombre);
      if (obj.tipoDocId !== undefined) tipoDocId = obj.tipoDocId;
      else return '';
    }

    const key = String(tipoDocId).trim();

    switch (key) {
      case '1': return 'Cédula de ciudadanía';
      case '2': return 'NIT';
      case '3': return 'Cédula de extranjería';
      case '4': return 'Pasaporte';
      case 'NIT': return 'NIT';
      case 'CC': return 'Cédula de ciudadanía';
      case 'CEDULA': return 'Cédula de ciudadanía';
      default: return key;
    }
  }

  // Única implementación consolidada de getinfoTable
  getinfoTable(showActive: boolean = this.showOnlyActive) {
    this.loading = true;
    const svc: any = this.service as any;

    
    // Intentar getList con filtro si lo soporta
    if (typeof svc.getList === 'function') {
      try {
        const obs = svc.getList({ activo: showActive });
        if (obs && typeof obs.subscribe === 'function') {
          obs.subscribe({
            next: (response: Cliente[]) => {
              this.allInfoTable = response.map(item => ({
                ...item,
                tipoDocLabel: this.getTipoDocLabel((item as any).tipoDocId ?? (item as any).TipoDocId)
              }));
              this.applyFilters();
              this.loading = false;
            },
            error: (error: any) => { this.loading = false; this.showError(error); }
          });
          return;
        }
      } catch {
        // continue to fallback
      }
    }

    // Fallback: traer todo y filtrar en frontend
    this.service.getList().subscribe({
      next: (response: Cliente[]) => {
        const filtered = response.filter(item => {
          const activeProp = (item as any).Activo ?? (item as any).activo ?? (item as any).isActive ?? true;
          const isActive = activeProp === undefined ? true : Boolean(activeProp);
          return showActive ? isActive : !isActive;
        });
        this.allInfoTable = filtered.map(item => ({
          ...item,
          tipoDocLabel: this.getTipoDocLabel((item as any).tipoDocId ?? (item as any).TipoDocId)
        }));
        this.applyFilters();
        this.loading = false;
      },
      error: (error) => { this.loading = false; this.showError(error); }
    });
  }

    // Aplica filtros locales sobre allInfoTable y setea infoTable
  applyFilters(): void {
    const nombre = (this.nombreFiltro || '').trim().toLowerCase();
    const tipo = (this.tipoFiltro || '').toString();

    this.infoTable = this.allInfoTable.filter(item => {
      const razon = (item.razonSocialTercero || '').toString().toLowerCase();
      const numero = (item.numeroDoc || '').toString().toLowerCase();
      const tipoId = ((item as any).tipoDocId ?? (item as any).TipoDocId ?? '').toString();

      const matchesNombre = nombre === '' || razon.includes(nombre) || numero.includes(nombre);
      const matchesTipo = tipo === '' || tipoId === tipo;

      return matchesNombre && matchesTipo;
    });
  }

  // Alternar vista entre activos e inactivos
  toggleActiveView(showActive: boolean) {
    this.showOnlyActive = showActive;
    this.getinfoTable(this.showOnlyActive);
  }

  // Desactivar cliente (soft-delete) con varios fallbacks según servicio
  deactivate(infoComponent: Cliente) {
    const id = Number((infoComponent as any).terceroId ?? (infoComponent as any).id);
    this.confirmationService.confirm({
      message: '¿Estás segura? Esta acción desactivará al cliente.',
      header: 'Confirmar desactivación',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        const svc: any = this.service as any;
        if (typeof svc.deactivate === 'function') {
          svc.deactivate(id).subscribe({
            next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente desactivado' }); this.getinfoTable(); },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo desactivar el cliente' }); }
          });
          return;
        }
        if (typeof svc.getById === 'function' && typeof svc.update === 'function') {
          svc.getById(id).subscribe({
            next: (existing: any) => {
              const toUpdate = { ...existing, Activo: false };
              svc.update(toUpdate).subscribe({
                next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente desactivado' }); this.getinfoTable(); },
                error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo desactivar el cliente' }); }
              });
            },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo obtener el cliente' }); }
          });
          return;
        }
        if (typeof svc.update === 'function') {
          const payload: any = { TerceroId: id, Activo: false };
          svc.update(payload).subscribe({
            next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente desactivado' }); this.getinfoTable(); },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo desactivar el cliente' }); }
          });
          return;
        }
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Operación no soportada por el servicio' });
      }
    });
  }

  reactivate(infoComponent: Cliente) {
    const id = Number((infoComponent as any).terceroId ?? (infoComponent as any).id);
    this.confirmationService.confirm({
      message: '¿Deseas reactivar este cliente?',
      header: 'Confirmar reactivación',
      icon: 'pi pi-check',
      accept: () => {
        const svc: any = this.service as any;
        if (typeof svc.reactivate === 'function') {
          svc.reactivate(id).subscribe({
            next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente reactivado' }); this.getinfoTable(); },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo reactivar el cliente' }); }
          });
          return;
        }
        if (typeof svc.getById === 'function' && typeof svc.update === 'function') {
          svc.getById(id).subscribe({
            next: (existing: any) => {
              const toUpdate = { ...existing, Activo: true };
              svc.update(toUpdate).subscribe({
                next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente reactivado' }); this.getinfoTable(); },
                error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo reactivar el cliente' }); }
              });
            },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo obtener el cliente' }); }
          });
          return;
        }
        if (typeof svc.update === 'function') {
          const payload: any = { TerceroId: id, Activo: true };
          svc.update(payload).subscribe({
            next: () => { this.messageService.add({ severity: 'success', summary: 'Listo', detail: 'Cliente reactivado' }); this.getinfoTable(); },
            error: () => { this.messageService.add({ severity: 'error', summary: 'Error', detail: 'No se pudo reactivar el cliente' }); }
          });
          return;
        }
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Operación no soportada por el servicio' });
      }
    });
  }

  new(){
    this.ref = this.dialogService.open(FormularioClientesComponent, {
      data: { action:'crear' },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true
    });
    // this.ref.onClose.subscribe(() => { this.getinfoTable(); });
  }

  edit(infoComponent: Cliente){
    this.ref = this.dialogService.open(FormularioClientesComponent, {
      data: {
        action:'actualizar',
        id: (infoComponent as any).terceroId ?? (infoComponent as any).id ?? '',
        tipoDocId: (infoComponent as any).tipoDocId ?? (infoComponent as any).TipoDocId ?? '',
        tipoDocLabel: (infoComponent as any).tipoDocLabel ?? this.getTipoDocLabel((infoComponent as any).tipoDocId ?? (infoComponent as any).TipoDocId),
        userId: (infoComponent as any).userId ?? '',
        userName: (infoComponent as any).userName ?? '',
        expenseTypeId: (infoComponent as any).expenseTypeId ?? undefined,
        expenseTypeName: (infoComponent as any).expenseTypeName ?? undefined,
        month: (infoComponent as any).month ?? undefined,
        year: (infoComponent as any).year ?? undefined,
        amount: (infoComponent as any).amount ?? undefined,
        numeroDoc: (infoComponent as any).numeroDoc ?? (infoComponent as any).NumeroDoc ?? '',
        razonSocialTercero: (infoComponent as any).razonSocialTercero ?? (infoComponent as any).RazonSocialTercero ?? '',
        direccionTercero: (infoComponent as any).direccionTercero ?? (infoComponent as any).DireccionTercero ?? '',
        telefonoTercero: (infoComponent as any).telefonoTercero ?? (infoComponent as any).TelefonoTercero ?? '',
        correoElectronicoTercero: (infoComponent as any).correoElectronicoTercero ?? (infoComponent as any).CorreoElectronicoTercero ?? ''
      },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getinfoTable(this.showOnlyActive);
    });
  }

  // Normaliza distintas formas de representar "activo"
  getIsActive(item: any): boolean {
    const v = item?.Activo ?? item?.activo ?? item?.isActive ?? false;
    return v === true || v === 'true' || v === 1 || v === '1';
  }

  getActiveLabel(item: any): string {
    return this.getIsActive(item) ? 'Activo' : 'Inactivo';
  }

  onColumnFilter(event: Event, field: string) {
    const input = event.target as HTMLInputElement;
    const value = input?.value?.trim() ?? '';

    const data = { field: field, value: value };

    const indiceExist = this.filters.findIndex(item => item.field === data.field);
    if(indiceExist !== -1) { this.filters.splice(indiceExist, 1); }
    if(data.value){ this.filters.push(data); }

    this.getinfoTable();
  }

  // focus del botón lupa: usa ViewChild si está disponible
  focusBusqueda(): void {
    if (this.searchInputRef && this.searchInputRef.nativeElement) {
      this.searchInputRef.nativeElement.focus();
      this.searchInputRef.nativeElement.select();
    } else {
      const el = document.getElementById('searchInput') as HTMLInputElement | null;
      if (el) { el.focus(); el.select(); }
    }
  }

  // Filtrado usado por el input y select del header
  filtrarClientes(): void {
    this.applyFilters();
  }

  private showError(error: any): void {
    if(error?.status === 400)
    {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: error.error?.message ?? error.message ?? 'Error'
      });
    }
    else{
      this.showMessage('error', 'Error', 'Algo salió mal, intente de nuevo');
    }
  }

  private showMessage(severity: 'success' | 'info' | 'warning' | 'error', summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }
}