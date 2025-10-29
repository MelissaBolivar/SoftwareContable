import { Component, OnInit, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
  FormArray
} from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { DropdownModule } from 'primeng/dropdown';
import { DynamicDialogRef, DynamicDialogConfig } from 'primeng/dynamicdialog';
import { MessageService } from 'primeng/api';
import { FacturasVentaService } from '../../../../shared/Service/facturasventa/facturasventa.service';
import { CreateOrUpdateFacturasVenta } from '../../../../shared/interfaces/CreateOrUpdateFacturasVenta.interface';
import { Cliente } from '../../../../shared/interfaces/cliente.interface';
import { ClienteService } from '../../../../shared/Service/cliente/cliente.service';

@Component({
  selector: 'app-formulario-facturasventa',
  standalone: true,
  templateUrl: './formulario-facturasventa.component.html',
  styleUrls: ['./formulario-facturasventa.component.scss'],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CalendarModule,
    ButtonModule,
    InputTextModule,
    InputTextareaModule,
    ProgressSpinnerModule,
    DropdownModule
  ],
  providers: [ClienteService, MessageService]
})
export class FormularioFacturasVentaComponent implements OnInit, AfterViewInit {
  componentForm: FormGroup;
  headerName = '';
  action = '';
  id = '';
  loading = false;

  tercero: any[] = [];
  producto: any[] = [];
  servicio: any[] = [];
  tipoPago: any[] = [];
  tipoFactura: any[] = [];
  anticipo: any[] = [];

  customLocale = {
    firstDayOfWeek: 1,
    dayNames: ['domingo', 'lunes', 'martes', 'miércoles', 'jueves', 'viernes', 'sábado'],
    dayNamesShort: ['dom', 'lun', 'mar', 'mié', 'jue', 'vie', 'sáb'],
    dayNamesMin: ['D', 'L', 'M', 'X', 'J', 'V', 'S'],
    monthNames: [
      'Enero','Febrero','Marzo','Abril','Mayo','Junio',
      'Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'
    ],
    monthNamesShort: ['Ene','Feb','Mar','Abr','May','Jun','Jul','Ago','Sep','Oct','Nov','Dic'],
    today: 'Hoy',
    clear: 'Limpiar'
  };

  constructor(
    private readonly fb: FormBuilder,
    public ref: DynamicDialogRef,
    public config: DynamicDialogConfig,
    private readonly service: FacturasVentaService,
    private readonly clienteService: ClienteService,
    private readonly messageService: MessageService
  ) {
    this.componentForm = this.fb.group({
      fecha: ['', Validators.required],
      numeroFactura: ['', Validators.required],
      terceroId: [null, Validators.required],
      tipoPagoId: [null, Validators.required],
      tipoFacturaId: [null, Validators.required],
      anticipoId: [null, Validators.required],
      detalleProducto: this.fb.array([]),
      detalleServicio: this.fb.array([]),
      total: [{ value: 0, disabled: true }, [Validators.required, Validators.min(0)]],
      observaciones: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.action = this.config.data?.action || '';
    this.headerName = this.config.data?.name || '';

    this.clienteService.getList().subscribe((data: Cliente[]) => {
      this.tercero = data.map(c => ({ terceroId: c.terceroId, nombre: c.razonSocialTercero }));
    });

    this.service.getProducto().subscribe(data => {
      this.producto = data.map(p => ({ productoId: p.productoId, nombre: p.nombre }));
    });

    this.service.getServicio().subscribe(data => {
      this.servicio = data.map(s => ({ servicioId: s.servicioId, nombre: s.nombre }));
    });

    // Normalizar tipoPago a tipoPagoId y añadir log de verificación
    this.service.getTipoPago().subscribe(data => {
      this.tipoPago = data.map(p => ({
        tipoPagoId: p.tipoPagoId ?? p.TipoPagoId ?? p.id ?? p.Tipo_PagoId ?? null,
        nombre: p.nombre
      }));
      console.log('tipoPago normalizado', this.tipoPago);
    });

    this.service.getTipoFactura().subscribe(data => {
      this.tipoFactura = data
        .map(f => ({ tipoFacturaId: f.tipoFacturaId ?? f.TipoFacturaId ?? f.id ?? null, nombre: f.nombre }))
        .filter(f => f.nombre?.toLowerCase() === 'venta');

      if (this.tipoFactura.length === 1 && this.action !== 'Actualizar') {
        this.componentForm.get('tipoFacturaId')?.setValue(this.tipoFactura[0].tipoFacturaId);
      }
    });

    this.service.getAnticipo().subscribe(data => {
      this.anticipo = data.map(a => ({ anticipoId: a.anticipoId, nombre: `${a.porcentajeAnticipo}%` }));
    });

    if (this.action === 'Actualizar' || this.action === 'ver') {
      this.id = this.config.data.id;
      const fecha = this.config.data.fecha ? new Date(this.config.data.fecha) : null;

      this.componentForm.patchValue({
        fecha: fecha,
        numeroFactura: this.config.data.numeroFactura,
        terceroId: this.config.data.terceroId,
        tipoPagoId: this.config.data.tipoPagoId ?? this.config.data.TipoPagoId ?? this.config.data.Tipo_PagoId ?? null,
        tipoFacturaId: this.config.data.tipoFacturaId ?? this.config.data.TipoFacturaId ?? null,
        anticipoId: this.config.data.anticipoId,
        observaciones: this.config.data.observaciones,
        total: this.config.data.total
      });
      debugger;
      if (this.config.data.detalleProducto?.length) {
        const productosForm = this.config.data.detalleProducto.map((item: any) =>
          this.fb.group({
            productoId: [item.productoId, Validators.required],
            unidades: [item.unidades, [Validators.required, Validators.min(1)]],
            precio: [item.precioUnitario, [Validators.required, Validators.min(0)]]
          })
        );
        this.componentForm.setControl('detalleProducto', this.fb.array(productosForm));
      }

      if (this.config.data.detalleServicio?.length) {
        const serviciosForm = this.config.data.detalleServicio.map((item: any) =>
          this.fb.group({
            servicioId: [item.servicioId, Validators.required],
            unidades: [item.unidades, [Validators.required, Validators.min(1)]],
            precio: [item.precioUnitario, [Validators.required, Validators.min(0)]]
          })
        );
        this.componentForm.setControl('detalleServicio', this.fb.array(serviciosForm));
      }
    } else {
      this.agregarProducto();
      this.agregarServicio();
    }

    // Log del config.data para depuración en modo edición
    console.log('config.data (editar):', this.config.data);

    if (this.action === 'ver') {
  this.componentForm.disable(); // deshabilita todos los controles
}
  }

    ngAfterViewInit(): void {
    this.detalleProducto?.controls?.forEach(grupo => {
      grupo.get('unidades')?.valueChanges.subscribe(() => this.updateTotal());
      grupo.get('precio')?.valueChanges.subscribe(() => this.updateTotal());
    });

    this.detalleServicio?.controls?.forEach(grupo => {
      grupo.get('unidades')?.valueChanges.subscribe(() => this.updateTotal());
      grupo.get('precio')?.valueChanges.subscribe(() => this.updateTotal());
    });
  }

  agregarProducto(): void {
    const grupo = this.fb.group({
      productoId: [null, Validators.required],
      unidades: [1, [Validators.required, Validators.min(1)]],
      precio: [0, [Validators.required, Validators.min(0)]]
    });

    grupo.get('unidades')?.valueChanges.subscribe(() => this.updateTotal());
    grupo.get('precio')?.valueChanges.subscribe(() => this.updateTotal());

    this.detalleProducto.push(grupo);
  }

  agregarServicio(): void {
    const grupo = this.fb.group({
      servicioId: [null, Validators.required],
      unidades: [1, [Validators.required, Validators.min(1)]],
      precio: [0, [Validators.required, Validators.min(0)]]
    });

    grupo.get('unidades')?.valueChanges.subscribe(() => this.updateTotal());
    grupo.get('precio')?.valueChanges.subscribe(() => this.updateTotal());

    this.detalleServicio.push(grupo);
  }

  private updateTotal(): void {
    const productos = this.detalleProducto.controls;
    const servicios = this.detalleServicio.controls;

    const totalProductos = productos.reduce((acc, grupo) => {
      const unidades = grupo.get('unidades')?.value || 0;
      const precio = grupo.get('precio')?.value || 0;
      return acc + unidades * precio;
    }, 0);

    const totalServicios = servicios.reduce((acc, grupo) => {
      const unidades = grupo.get('unidades')?.value || 0;
      const precio = grupo.get('precio')?.value || 0;
      return acc + unidades * precio;
    }, 0);

    const total = totalProductos + totalServicios;
    this.componentForm.get('total')?.setValue(total, { emitEvent: false });
  }

  guardar(): void {
    if (!this.componentForm.valid) { return; }

    // Logs de verificación para depuración
    const raw = this.componentForm.getRawValue();
    console.log('FORM RAW (antes de payload):', raw);
    console.log('valor tipoPagoId seleccionado:', raw.tipoPagoId);

    const tipoFacturaSeleccionado = this.tipoFactura.find(
      t => t.tipoFacturaId === this.componentForm.get('tipoFacturaId')?.value
    );

    if (tipoFacturaSeleccionado?.nombre?.toLowerCase() !== 'venta') {
      this.messageService.add({
        severity: 'warn',
        summary: 'Tipo de Factura inválido',
        detail: 'Solo se permite guardar facturas de tipo Venta.'
      });
      return;
    }

    this.loading = true;
    const formData = raw;
    debugger;
    const payload: CreateOrUpdateFacturasVenta = {
      ...(this.action === 'Actualizar' && { FacturaId: Number(this.id) }),
      Fecha: formData.fecha,
      NumeroFactura: formData.numeroFactura,
      TerceroId: formData.terceroId,
      TipoPagoId: formData.tipoPagoId,
      TipoFacturaId: formData.tipoFacturaId,
      AnticipoId: formData.anticipoId,
      Productos: formData.detalleProducto,
      Servicios: formData.detalleServicio,
      Observaciones: formData.observaciones,
      Total: formData.total
      
    };

    const request = this.action === 'Crear' ? this.service.create(payload) : this.service.update(payload);

    request.subscribe({
      next: () => {
        this.loading = false;
        window.dispatchEvent(new Event('facturaGuardada'));
        this.onClose();
      },
      error: (error) => {
        this.loading = false;
        this.showError(error);
      }
    });
  }

  onClose(): void {
    this.componentForm.reset();
    if (this.ref) {
      this.ref.close();
    }
  }

  private showError(error: any): void {
    const message = error?.error?.message || 'Algo salió mal, intente de nuevo';
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: message
    });
  }

  // Helper consistente para obtener nombre desde cualquier colección normalizada
  getNombre(collection: any[], id: any): string {
    if (!collection || id == null) { return '—'; }
    const it = collection.find(x =>
      x.tipoPagoId === id ||
      x.terceroId === id ||
      x.productoId === id ||
      x.servicioId === id ||
      x.tipoFacturaId === id ||
      x.anticipoId === id ||
      x.id === id ||
      x.TipoPagoId === id ||
      x.TipoFacturaId === id
    );
    return it ? it.nombre : '—';
  }

  get detalleProducto(): FormArray {
    return this.componentForm.get('detalleProducto') as FormArray;
  }

  get detalleServicio(): FormArray {
    return this.componentForm.get('detalleServicio') as FormArray;
  }
}
