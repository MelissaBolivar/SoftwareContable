using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class TipoDePago
    {
        [Key]
        public int TipoPagoId  { get; set; }
        public required string NombreTipoPago  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }
        public ICollection<Gastos>? Gastos { get; set; }
        public ICollection<Costos>? Costos { get; set; }
        public ICollection<Compras>? Compras { get; set; }
        public ICollection<Ventas>? Ventas { get; set; }

    }
}
