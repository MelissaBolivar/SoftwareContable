using Contable.Application.Dtos.DetalleProducto;
using Contable.Application.Dtos.DetalleServicio;
using System;
using System.Collections.Generic;

namespace Contable.Application.Dtos.Factura
{
    public class CreateFacturaDto
    {
        public int FacturaId { get; set; }
        public int TerceroId { get; set; }
        public int TipoPagoId { get; set; }
        public int TipoFacturaId { get; set; }
        public int AnticipoId { get; set; }

        public DateTime Fecha { get; set; }
        public int NumeroFactura { get; set; }
        public string? Observaciones { get; set; }
        public int Total { get; set; }

        // Nuevas listas de detalle
        public List<CreateDetalleProductoDto> Productos { get; set; } = new();
        public List<CreateDetalleServicioDto> Servicios { get; set; } = new();
        

    }
}