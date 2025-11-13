import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { InputTextModule } from 'primeng/inputtext';
import { MessageService } from 'primeng/api';
import { forkJoin } from 'rxjs';
import { InventarioService } from '../../shared/Service/inventario/inventario.service';
import { FacturasCompraService } from '../../shared/Service/facturascompra/facturascompra.service';
import { FacturasVentaService } from '../../shared/Service/facturasventa/facturasventa.service';
import { Inventario } from '../../shared/interfaces/inventario.interface';

@Component({
  selector: 'app-caja',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    TableModule,
    ButtonModule,
    InputTextModule
  ],
  providers: [
    InventarioService,
    FacturasCompraService,
    FacturasVentaService,
    MessageService
  ],
  templateUrl: './caja.component.html',
  styleUrl: './caja.component.scss'
})
export class CajaComponent implements OnInit {
  infoTable: Inventario[] = [];
  loading = true;

  constructor(
    private readonly CajaService: InventarioService,
    private readonly facturasCompraService: FacturasCompraService,
    private readonly facturasVentaService: FacturasVentaService,
    private readonly messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.getinfoTableFromFacturas();
  }

  // botón "Consultar inventario"
  new(): void {
    this.getinfoTableFromFacturas();
  }

  // 🔍 Método del filtro global (nuevo)
  onGlobalFilter(event: Event, table: any): void {
    const value = (event.target as HTMLInputElement).value;
    table.filterGlobal(value, 'contains');
  }

  // Obtiene facturas de compra y venta, extrae DetalleProducto y calcula unidades
  private getinfoTableFromFacturas(): void {
    this.loading = true;

    forkJoin({
      inventario: this.CajaService.getList()
    }).subscribe({
      next: ({ inventario }) => {
        // convertir a array con el shape que espera la interfaz Inventario y evitar negativos
        this.infoTable = Array.from(inventario.values()).map(v => ({
          inventarioId: Number(v.inventarioId),
          producto: String(v.producto),
          unidades: Math.max(0, Number(v.unidades)),
          precioCompra: Number(v.precioCompra ?? 0),
          precioVenta: Number(v.precioVenta ?? 0),
          nombre: String(v.nombre),
          codigo: String(v.codigo)
        }));

        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'No se pudo cargar datos desde facturas'
        });
        console.error(err);
      }
    });
  }

  // mantengo método de error por compatibilidad
  private showError(error: any): void {
    const detail = error?.error?.message ?? 'Algo salió mal, intente de nuevo';
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail
    });
  }
}
