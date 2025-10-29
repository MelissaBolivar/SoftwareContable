using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public int TerceroId { get; set; }
        public int TipoPagoId { get; set; }
        public int TipoFacturaId { get; set; }
        public int AnticipoId { get; set; }
        public int CajaId { get; set; }
        public int InventarioId { get; set; }

        public DateTime Fecha { get; set; }
        public int NumeroFactura { get; set; }
        public string Observaciones { get; set; }

        public int Total { get; set; }
        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        // Propiedades de navegación
        public Tercero Tercero { get; set; }
        public TipoPago TipoDePago { get; set; }
        public TipoFactura TipoFactura { get; set; }
        public Anticipo Anticipo { get; set; }
        public Caja Caja { get; set; }
        public Inventario Inventario { get; set; }

        // Nuevas relaciones con detalles
        public ICollection<DetalleProducto> Productos { get; set; } = new List<DetalleProducto>();
        public ICollection<DetalleServicio> Servicios { get; set; } = new List<DetalleServicio>();
        
    }
}