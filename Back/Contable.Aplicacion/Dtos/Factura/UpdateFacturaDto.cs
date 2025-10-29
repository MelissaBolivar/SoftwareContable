using Contable.Application.Dtos.DetalleProducto;
using Contable.Application.Dtos.DetalleServicio;

namespace Contable.Application.Dtos.Factura
{
    public class UpdateFacturaDto
    {
        public int FacturaId { get; set; }
        public int TerceroId { get; set; }
        public int TipoPagoId { get; set; }
        public int TipoFacturaId { get; set; }
        public int AnticipoId { get; set; }

        public required DateTime Fecha { get; set; }
        public required int NumeroFactura { get; set; }
        public required string Observaciones { get; set; }

        public int Total { get; set; }

        // Nuevas listas de detalle
        public List<UpdateDetalleProductoDto> Productos { get; set; } = new();
        public List<UpdateDetalleServicioDto> Servicios { get; set; } = new();
        public List<UpdateDetalleProductoDto> Compras { get; set; } = new();
    }
}