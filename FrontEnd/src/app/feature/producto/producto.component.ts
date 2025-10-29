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

import { ProductoService } from '../../shared/Service/producto/producto.service';
import { Producto } from '../../shared/interfaces/producto.interface';
import { FormularioProductoComponent } from './component/formulario-producto/formulario-producto.component';

@Component({
  selector: 'app-producto',
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
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent implements OnInit, OnDestroy {
  @ViewChild('searchInput') searchInput!: ElementRef<HTMLInputElement>;

  infoTable: Producto[] = [];
  productosDesactivados: Producto[] = [];
  private allInfoTable: Producto[] = [];
  private allProductosDesactivados: Producto[] = [];

  loading = true;
  ref!: DynamicDialogRef | null;
  nombreFiltro = '';

  toggleActive = true;
  toggleInactive = true;
  rowsActive = 10;
  rowsInactive = 5;

  private readonly destroy$ = new Subject<void>();

  constructor(
    private readonly service: ProductoService,
    private readonly dialogService: DialogService,
    private readonly confirmationService: ConfirmationService,
    private readonly messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.getInfoTable();
    this.getProductosDesactivados();
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
        next: (response: Producto[]) => {
          this.allInfoTable = Array.isArray(response) ? response : [];
          this.applyNombreFilter();
          this.loading = false;
        },
        error: (error) => {
          this.loading = false;
          this.showMessage('error', 'Error', 'No se pudo cargar productos activos');
          console.error('Error cargando productos activos:', error);
        }
      });
  }

  getProductosDesactivados(): void {
    this.service.getDesactivados()
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (response: Producto[]) => {
          this.allProductosDesactivados = Array.isArray(response) ? response : [];
          this.applyNombreFilter();
        },
        error: (error) => {
          this.showMessage('error', 'Error', 'No se pudieron cargar productos desactivados');
          console.error('Error cargando productos desactivados:', error);
        }
      });
  }

  filtrarProductos(): void {
    this.applyNombreFilter();
  }

  private applyNombreFilter(): void {
    const q = (this.nombreFiltro ?? '').toString().trim().toLowerCase();
    if (!q) {
      this.infoTable = [...this.allInfoTable];
      this.productosDesactivados = [...this.allProductosDesactivados];
      return;
    }

    this.infoTable = this.allInfoTable.filter(p =>
      (p?.nombre ?? '').toString().toLowerCase().includes(q) ||
      (p?.codigo ?? '').toString().toLowerCase().includes(q)
    );

    this.productosDesactivados = this.allProductosDesactivados.filter(p =>
      (p?.nombre ?? '').toString().toLowerCase().includes(q) ||
      (p?.codigo ?? '').toString().toLowerCase().includes(q)
    );
  }

  filterInactive(): void {
    this.toggleInactive = !this.toggleInactive;
  }

  new(): void {
    this.ref = this.dialogService.open(FormularioProductoComponent, {
      data: { action: 'Crear' },
      width: '90%',
      height: '100%',
      contentStyle: { 'max-height': '700px', overflow: 'auto' },
      dismissableMask: true
    });

    this.ref.onClose.subscribe(() => {
      this.getInfoTable();
      this.getProductosDesactivados();
    });
  }

  edit(infoComponent: Producto, event?: Event): void {
    event?.stopPropagation();

    this.ref = this.dialogService.open(FormularioProductoComponent, {
      data: {
        action: 'actualizar',
        productoId: infoComponent.productoId,
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
      this.getProductosDesactivados();
    });
  }

  confirmDesactivar(productoId: number, nombre?: string): void {
    this.confirmationService.confirm({
      message: `¿Estás segura que quieres desactivar el producto "${nombre ?? productoId}"?`,
      header: 'Confirmar desactivación',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Sí',
      rejectLabel: 'No',
      accept: () => this.desactivar(productoId),
      reject: () => {}
    });
  }

  desactivar(productoId: number): void {
    this.service.delete(productoId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: { mensaje: string }) => {
          this.showMessage('info', 'Producto', res?.mensaje ?? 'Producto desactivado');
          setTimeout(() => {
            this.getInfoTable();
            this.getProductosDesactivados();
          }, 400);
        },
        error: (err) => {
          const mensaje = err?.error?.mensaje || 'Error desactivando el producto';
          this.showMessage('error', 'Error', mensaje);
          console.error('Error desactivando producto:', err);
        }
      });
  }

  confirmReactivar(productoId: number, nombre?: string): void {
    this.confirmationService.confirm({
      message: `¿Estás segura que quieres reactivar el producto "${nombre ?? productoId}"?`,
      header: 'Confirmar reactivación',
      icon: 'pi pi-check-circle',
      acceptLabel: 'Sí',
      rejectLabel: 'No',
      accept: () => this.reactivar(productoId),
      reject: () => {}
    });
  }

  reactivar(productoId: number): void {
    this.service.reactivar(productoId)
      .pipe(takeUntil(this.destroy$))
      .subscribe({
        next: (res: { mensaje: string }) => {
          this.showMessage('success', 'Producto', res?.mensaje ?? 'Producto reactivado');
          setTimeout(() => {
            this.getInfoTable();
            this.getProductosDesactivados();
          }, 400);
        },
        error: (err) => {
          const mensaje = err?.error?.mensaje || 'Error reactivando el producto';
          this.showMessage('error', 'Error', mensaje);
          console.error('Error reactivando producto:', err);
        }
      });
  }

  private showMessage(severity: 'success' | 'info' | 'warn' | 'error', summary: string, detail: string): void {
    this.messageService.add({ severity, summary, detail });
  }
}
