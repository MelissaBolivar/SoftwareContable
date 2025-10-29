import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { TableModule } from 'primeng/table';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { FormularioFacturasVentaComponent } from './component/formulario-facturasventa/formulario-facturasventa.component';
import { FacturasVenta } from '../../shared/interfaces/facturasventa.interface';
import { FacturasVentaService } from '../../shared/Service/facturasventa/facturasventa.service';

@Component({
  selector: 'app-facturasventa',
  standalone: true,
  templateUrl: './facturasventa.component.html',
  styleUrls: ['./facturasventa.component.scss'],
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
  providers: [
    DialogService,
    ConfirmationService,
    FacturasVentaService,
    MessageService
  ],

  animations: [
    trigger('fadeInOut', [
      state('visible', style({ opacity: 1, height: '*' })),
      state('hidden', style({ opacity: 0, height: '0', overflow: 'hidden' })),
      transition('visible <=> hidden', [animate('300ms ease-in-out')]),
    ]),
  ]

})
export class FacturasVentaComponent implements OnInit {
  infoTable: FacturasVenta[] = [];
  loading = true;
  ref!: DynamicDialogRef;
  filters: { field: string; value: string }[] = [];

  tercero: any[] = [];
  producto: any[] = [];
  servicio: any[] = [];
  tipoPago: any[] = [];
  tipoFactura: any[] = [];
  anticipo: any[] = [];

  constructor(
    private readonly service: FacturasVentaService,
    public dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService
  ) {
    this.service.getTerceros().subscribe(data => this.tercero = data);
  }

  ngOnInit(): void {
    this.getinfoTable();
    this.service.getProducto().subscribe(data => this.producto = data);
    this.service.getServicio().subscribe(data => this.servicio = data);
    this.service.getTipoPago().subscribe(data => this.tipoPago = data);
    this.service.getTipoFactura().subscribe(data => this.tipoFactura = data);
    this.service.getAnticipo().subscribe(data => this.anticipo = data);
  }

  getinfoTable(): void {
    this.service.getList().subscribe({
      next: (response: any) => {
        const data = Array.isArray(response) ? response : [];
        console.log('Facturas recibidas desde el backend:', data);
        this.infoTable = data;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    });
  }

  delete(infoComponent: FacturasVenta): void {
    this.service.delete(infoComponent.facturaId).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Eliminado',
          detail: 'Factura eliminada correctamente'
        });
        this.getinfoTable();
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'No se pudo eliminar la factura'
        });
      }
    });
  }

  new(): void {
    this.ref = this.dialogService.open(FormularioFacturasVentaComponent, {
      data: { action: 'Crear' },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    if (this.ref) {
      this.ref.onClose.subscribe(() => {
        this.getinfoTable();
      });
    }
  }

  edit(infoComponent: FacturasVenta): void {
    this.ref = this.dialogService.open(FormularioFacturasVentaComponent, {
      data: {
        action: 'Actualizar',
        id: infoComponent.facturaId,
        fecha: infoComponent.fecha,
        numeroFactura: infoComponent.numeroFactura,
        terceroId: infoComponent.terceroId,
        TipoPagoId: infoComponent.tipoPagoId, // ✅ corregido
        tipoFacturaId: infoComponent.tipoFacturaId,
        anticipoId: infoComponent.anticipoId,
        detalleProducto: infoComponent.detalleProducto,
        detalleServicio: infoComponent.detalleServicio,
        total: infoComponent.total,
        observaciones: infoComponent.observaciones
      },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    if (this.ref) {
      this.ref.onClose.subscribe(() => {
        this.getinfoTable();
      });
    }
  }

  verFactura(infoComponent: FacturasVenta): void {
    this.ref = this.dialogService.open(FormularioFacturasVentaComponent, {
      data: {
        action: 'ver',
        id: infoComponent.facturaId,
        fecha: infoComponent.fecha,
        numeroFactura: infoComponent.numeroFactura,
        terceroId: infoComponent.terceroId,
        TipoPagoId: infoComponent.tipoPagoId, // ✅ corregido
        tipoFacturaId: infoComponent.tipoFacturaId,
        anticipoId: infoComponent.anticipoId,
        detalleProducto: infoComponent.detalleProducto,
        detalleServicio: infoComponent.detalleServicio,
        total: infoComponent.total,
        observaciones: infoComponent.observaciones
      },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    if (this.ref) {
      this.ref.onClose.subscribe(() => {
        this.getinfoTable();
      });
    }
  }

  onColumnFilter(event: Event, field: string): void {
    const input = event.target as HTMLInputElement;
    const value = input.value.trim();

    const index = this.filters.findIndex(item => item.field === field);
    if (index !== -1) {
      this.filters.splice(index, 1);
    }

    if (value) {
      this.filters.push({ field, value });
    }

    this.getinfoTable();
  }

  getNombre(lista: any[], id: number): string {
    const item = lista.find(x => x.id === id);
    return item ? item.nombre : '—';
  }

  getNombreTipoPago(lista: any[], id: number): string {
    const item = lista.find(x => x.tipoPagoId === id);
    return item ? item.nombre : '—';
  }

  getNombreTipoFactura(lista: any[], id: number): string {
    const item = lista.find(x => x.tipoFacturaId === id);
    return item ? item.nombre : '—';
  }

  getTotal(infoComponent: FacturasVenta): string {
  const total = infoComponent.total;

  return new Intl.NumberFormat('es-CO', {
    style: 'currency',
    currency: 'COP',
    minimumFractionDigits: 0
  }).format(total);
}
  getNombreTercero(lista: any[], id: number): string {
    const item = lista.find(x => x.id === id || x.terceroId === id); // ✅ compatible con ambos formatos
    return item ? item.razonSocialTercero || item.nombre : '—';
  }

  getAnticipo(lista: any[], id: number): string {
    const item = lista.find(x => x.anticipoId === id || x.id === id);
    return item ? item.porcentajeAnticipo || item.nombre : '—';
  }

  private showError(error: any): void {
    const message = error?.error?.message || 'Algo salió mal, intente de nuevo';
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: message
    });
  }
}
