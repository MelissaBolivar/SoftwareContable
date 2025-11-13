import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
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
import { FormularioColaboradoresComponent } from './component/formulario-colaboradores/formulario-colaboradores.component';
import { Cliente } from '../../shared/interfaces/cliente.interface';
import { Colaborador } from '../../shared/interfaces/colaborador.interface';
import { ColaboradorService } from '../../shared/Service/colaborador/colaborador.service';
import { ToastModule } from 'primeng/toast';

@Component({
  selector: 'app-colaboradores',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    CalendarModule,
    ConfirmDialogModule,
    InputTextModule,
    ToastModule
  ],
  providers:[
    DialogService,
    ConfirmationService,
    // Colaboradorservice se provee en root; no debe listarse aquí
    HttpService,
    UserService,
    MessageService
  ],
  templateUrl: './colaboradores.component.html',
  styleUrls: ['./colaboradores.component.scss']
})
export class ColaboradoresComponent implements OnInit {
  @ViewChild('dt1') dt1: any;

  // lista que se muestra en la tabla
  infoTable!: Colaborador[];
  // copia completa de los datos (se usa para filtrar)
  allInfo: Colaborador[] = [];

  // lista de tipos de documento (id -> nombre)
  listTipoDocumento: { tipoDocId: number; nombre: string }[] = [];

  loading = true;
  ref!: DynamicDialogRef;
  filters: FieldFilter[] = [];
  columnFilters: Record<string, string> = {};
  nombreFiltro: string = '';
  tipoFiltro: any = '';
  estadoFiltro: any = '';

  constructor(
    private readonly service: ColaboradorService,
    public dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService
  ) {}

  ngOnInit() {
    this.getinfoTable();
    this.loadTiposDocumento();
  }

  // carga la lista desde el servicio y guarda una copia completa
  getinfoTable(){
    this.service.getList().subscribe({
      next: (response: Colaborador[]) => {
        // Normalizo el campo de estado para la UI sin cambiar la lógica del backend
        // Creo un alias `estado` (boolean) a partir de Activo / activo / estado que venga
        this.allInfo = (response || []).map(item => {
          const activoRaw = (item as any).Activo ?? (item as any).activo ?? (item as any).estado;
          const activoBool = activoRaw === true || activoRaw === 'true' || activoRaw === 1 || activoRaw === '1';
          return {
            ...item,
            // mantenemos las propiedades originales y añadimos el alias booleano
            Activo: activoBool,
            estado: activoBool,
            // normalizar id si hace falta (no rompe si ya exista)
            TerceroId: (item as any).TerceroId ?? (item as any).terceroId
          } as Colaborador;
        });

        this.infoTable = [...this.allInfo];
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    })
  }

  // carga los tipos de documento para mostrar el nombre en la tabla
  loadTiposDocumento(): void {
    // si el servicio no tiene el método, uso la lista semilla para no romper la UI
    if (typeof this.service.getTiposDocumento !== 'function') {
      this.listTipoDocumento = [
        { tipoDocId: 1, nombre: 'Cédula de ciudadanía' },
        { tipoDocId: 2, nombre: 'NIT' },
        { tipoDocId: 3, nombre: 'Cédula de extranjería' },
        { tipoDocId: 4, nombre: 'Pasaporte' }
      ];
      return;
    }

    this.service.getTiposDocumento().subscribe({
      next: (res: any[]) => {
        this.listTipoDocumento = (res || []).map(r => ({
          tipoDocId: r.TipoDocId ?? r.tipoDocId ?? r.id,
          nombre: r.Nombre ?? r.nombre ?? r.name
        }));
        if (!this.listTipoDocumento.length) {
          this.listTipoDocumento = [
            { tipoDocId: 1, nombre: 'Cédula de ciudadanía' },
            { tipoDocId: 2, nombre: 'NIT' },
            { tipoDocId: 3, nombre: 'Cédula de extranjería' },
            { tipoDocId: 4, nombre: 'Pasaporte' }
          ];
        }
      },
      error: () => {
        this.listTipoDocumento = [
          { tipoDocId: 1, nombre: 'Cédula de ciudadanía' },
          { tipoDocId: 2, nombre: 'NIT' },
          { tipoDocId: 3, nombre: 'Cédula de extranjería' },
          { tipoDocId: 4, nombre: 'Pasaporte' }
        ];
      }
    });
  }

    // devuelve el nombre del tipo por su id; si no lo encuentra, muestra el id
  getTipoDocLabel(id: number | string): string {
    if (id == null) return '';
    const found = this.listTipoDocumento.find(x => String(x.tipoDocId) === String(id));
    return found ? found.nombre : String(id);
  }

  // Nota: la acción "eliminar" no aplica en este módulo.
  // Mantengo un helper que delega a desactivar para compatibilidad con botones antiguos
  delete(infoComponent: Colaborador) {
    this.desactivar(infoComponent);
  }

  new(){
    this.ref = this.dialogService.open(FormularioColaboradoresComponent, {
      data: { action:'Crear' },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getinfoTable();
    });
  }

  edit(infoComponent: Colaborador){
    this.ref = this.dialogService.open(FormularioColaboradoresComponent, {
      data: {
        action:'actualizar',
        id: (infoComponent as any).TerceroId ?? (infoComponent as any).terceroId,
        tipoDocId: infoComponent.tipoDocId,
        userId: (infoComponent as any).userId,
        userName: (infoComponent as any).userName,
        expenseTypeId: (infoComponent as any).expenseTypeId,
        expenseTypeName: (infoComponent as any).expenseTypeName,
        month: (infoComponent as any).month,
        year: (infoComponent as any).year,
        amount: (infoComponent as any).amount,
        numeroDoc: infoComponent.numeroDoc,
        razonSocialTercero: infoComponent.razonSocialTercero,
        direccionTercero: infoComponent.direccionTercero,
        telefonoTercero: infoComponent.telefonoTercero,
        correoElectronicoTercero: infoComponent.correoElectronicoTercero,
      },
      width: '90%',
      height: '100%',
      contentStyle: { "max-height": "700px", "overflow": "auto" },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getinfoTable();
    });
  }

  onColumnFilter(event: Event, field: string) {
    const input = event.target as HTMLInputElement;
    const value = input.value.trim();

    const data = {
      field: field,
      value : value
    }

    const indiceExist = this.filters.findIndex(item => item.field === data.field);

    if(indiceExist !== -1) {
      this.filters.splice(indiceExist, 1);
    }

    if(data.value){
      this.filters.push(data);
    }

    // Guardar para uso por lógica personalizada
    this.columnFilters[field] = value;

    this.getinfoTable();
  }

  onTipoFilter(event: Event): void {
    const value = (event.target as HTMLSelectElement).value;
    this.tipoFiltro = value;
    if (this.dt1 && (this.dt1 as any).filter) {
      (this.dt1 as any).filter(value, 'tipoDocId', 'contains');
      return;
    }
    this.getinfoTable();
  }

onEstadoFilter(event: Event): void {
  const select = event.target as HTMLSelectElement;

  // Intento obtener la opción real seleccionada
  const selectedIndex = select.selectedIndex;
  const optionEl = select.options && select.options[selectedIndex];
  let filterValue: boolean | null = null;

  // Normalizar distintos formatos: booleano, 'true'/'false' o ''
  if (optionEl) {
    const optVal = optionEl.value;
    if (optVal === '') {
      filterValue = null;
    } else if (optVal === 'true' || optVal === 'false') {
      filterValue = optVal === 'true';
    }
  }

  // Si aún no se determinó (por ngValue que a veces no aparece como string), intentar otras fuentes
  if (filterValue === null) {
    const raw = select.value;
    const selOpt = (select as any).selectedOptions && (select as any).selectedOptions[0];
    const candidate = selOpt ? selOpt.value : raw;

    if (candidate === '') {
      filterValue = null;
    } else if (candidate === 'true' || candidate === 'false') {
      filterValue = candidate === 'true';
    } else {
      // último recurso: si viene string 'true'/'false' en raw
      if (raw === 'true' || raw === 'false') {
        filterValue = raw === 'true';
      } else {
        filterValue = null;
      }
    }
  }

  this.estadoFiltro = filterValue;

  // Aplicar filtro a p-table (si está disponible)
  if (this.dt1 && (this.dt1 as any).filter) {
    if (filterValue === null) {
      (this.dt1 as any).filter(null, 'Activo', 'equals');
    } else {
      (this.dt1 as any).filter(filterValue, 'Activo', 'equals');
    }
    return;
  }

  // Filtro local cuando no se usa p-table.filter
  if (filterValue === null) {
    this.infoTable = [...this.allInfo];
  } else {
    this.infoTable = this.allInfo.filter(i => {
      const estadoBackend = (i as any).estado ?? (i as any).Activo;
      const estadoBool = estadoBackend === true || estadoBackend === 'true' || estadoBackend === 1 || estadoBackend === '1';
      return estadoBool === filterValue;
    });
  }
}

  // FILTRO GLOBAL SIMPLE (por nombre, número o correo)
  onGlobalFilter(event: Event): void {
    // tomo el texto que escribiste y lo dejo en minúsculas para comparar bien
    const val = (event.target as HTMLInputElement).value?.trim().toLowerCase() ?? '';
    this.nombreFiltro = val;

    // si el texto está vacío, muestro todo otra vez
    if (!val) {
      this.infoTable = [...this.allInfo];
      return;
    }

    // filtro la lista local: busco coincidencias en nombre, número o correo
    this.infoTable = this.allInfo.filter(item => {
      const nombre = (item.razonSocialTercero ?? '').toString().toLowerCase();
      const numero = (item.numeroDoc ?? '').toString().toLowerCase();
      const correo = (item.correoElectronicoTercero ?? '').toString().toLowerCase();

      return nombre.includes(val) || numero.includes(val) || correo.includes(val);
    });
  }
  // --- fin handlers ---

  private showError(error: any): void {
    if(error?.status === 400)
    {
      this.messageService.add({
        key: 'alerta',
        severity: 'error',
        summary: 'Error',
        detail: error.error?.message ?? 'Error servidor',
      });
    }
    else{
      this.showMessage('error', 'Error', 'Algo salió mal, intente de nuevo');
    }
  }

  private showMessage(severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string): void {
    this.messageService.add({
      key: 'alerta',
      severity,
      summary,
      detail
    });
  }

  /**
   * Actualiza el estado localmente en allInfo e infoTable.
   * Úsala tras reactivar/desactivar si no quieres recargar toda la lista.
   */
  private updateLocalEstado(terceroId: number, activo: boolean): void {
    const idxAll = this.allInfo.findIndex(i => Number((i as any).TerceroId ?? (i as any).terceroId) === terceroId);
    if (idxAll !== -1) {
      this.allInfo[idxAll] = { ...this.allInfo[idxAll], Activo: activo, estado: activo } as Colaborador;
    }

    const idxView = this.infoTable.findIndex(i => Number((i as any).TerceroId ?? (i as any).terceroId) === terceroId);
    if (idxView !== -1) {
      this.infoTable[idxView] = { ...this.infoTable[idxView], Activo: activo, estado: activo } as Colaborador;
    }
  }

  // --- métodos para activar / desactivar (llaman al servicio y actualizan UI) ---

  desactivar(infoComponent: Colaborador): void {
    const id = Number((infoComponent as any).TerceroId ?? (infoComponent as any).terceroId);
    if (isNaN(id)) return;

    // Preferimos llamar al endpoint explícito de desactivación si existe
    if (typeof this.service.deactivate === 'function') {
      this.service.deactivate(id).subscribe({
        next: () => {
          this.showMessage('success', 'Colaborador', 'Colaborador Desactivado Correctamente');
          this.updateLocalEstado(id, false);
        },
        error: () => this.showMessage('error', 'Error', 'No se pudo desactivar el colaborador')
      });
      return;
    }

    // Fallback: usar delete (soft-delete) si no hay endpoint específico
    this.service.delete(id).subscribe({
      next: () => {
        this.showMessage('success', 'Colaborador', 'Colaborador Desactivado Correctamente');
        this.updateLocalEstado(id, false);
      },
      error: () => this.showMessage('error', 'Error', 'No se pudo desactivar el colaborador')
    });
  }

  reactivar(infoComponent: Colaborador): void {
    const id = Number((infoComponent as any).TerceroId ?? (infoComponent as any).terceroId);
    if (isNaN(id)) return;

    if (typeof this.service.reactivate === 'function') {
      this.service.reactivate(id).subscribe({
        next: () => {
          this.showMessage('success', 'Colaborador', 'Colaborador Activado Correctamente');
          this.updateLocalEstado(id, true);
        },
        error: () => this.showMessage('error', 'Error', 'No se pudo reactivar el colaborador')
      });
      return;
    }

    // Si no existe reactivar, intentar llamar a un endpoint genérico (PUT/PATCH) si lo tienes implementado
    if (typeof this.service.activate === 'function') {
      this.service.activate(id).subscribe({
        next: () => {
          this.showMessage('success', 'Colaborador', 'Colaborador Activado Correctamente');
          this.updateLocalEstado(id, true);
        },
        error: () => this.showMessage('error', 'Error', 'No se pudo reactivar el colaborador')
      });
      return;
    }

    // Si no hay endpoint de reactivación, recargar lista completa como fallback
    this.getinfoTable();
  }
}