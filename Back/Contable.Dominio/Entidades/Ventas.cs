using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId  { get; set; }
        public int IdCliente  { get; set; }
        public int IdTipoPago  { get; set; }
        public int IdAnticipo  { get; set; }
        public required int UnidadesVenta  { get; set; }
        public required int PrecioVenta  { get; set; }
        public required DateTime FechaVenta  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        // 🔹 Navegación
        public Clientes? Cliente { get; set; }
        public TipoDePago? TipoPago { get; set; }
        public Anticipos? Anticipo { get; set; }
        public Rol? Rol { get; set; }
    }
}
