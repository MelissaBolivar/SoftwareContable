export interface DetalleProductoDto {
  productoId: number;
  unidades: number;
  precio: number;
}

export interface DetalleServicioDto {
  servicioId: number;
  unidades: number;
  precio: number;
}

export interface CreateOrUpdateFacturasVenta {
  FacturaId?: number;
  Fecha: string;
  NumeroFactura: number;
  TerceroId: number;
  TipoPagoId: number;
  TipoFacturaId: number;
  AnticipoId: number;
  Observaciones: string;
  Total: number;
  Productos: DetalleProductoDto[];
  Servicios: DetalleServicioDto[];

}