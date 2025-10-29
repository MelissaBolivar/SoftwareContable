using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class DetalleServicio
    {
        [Key]
        public int DetalleServicioId { get; set; }

        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }

        public int Unidades { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}