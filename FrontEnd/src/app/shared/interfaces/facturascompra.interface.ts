export interface FacturasCompra {
  facturaId: number;
  fecha: string;
  numeroFactura: number;
  terceroId: number;
  tipoPagoId: number;
  tipoFacturaId: number;
  anticipoId: number;
  total: number;
  observaciones: string;

  // Nuevas propiedades para compatibilidad con el formulario
  detalleProducto: {
    productoId: number;
    unidades: number;
    precio: number;
  }[];

  detalleServicio: {
    servicioId: number;
    unidades: number;
    precio: number;
  }[];
}