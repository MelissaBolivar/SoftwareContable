using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Compras
    {
        [Key]
        public int ComprasId  { get; set; }
        public int IdProveedor  { get; set; }
        public int IdTipoPago  { get; set; }
        public required int UnidadesCompra  { get; set; }
        public required int PrecioCompra  { get; set; }
        public required DateTime FechaCompra  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public Proveedores? Proveedor { get; set; }
        public TipoDePago? TipoDePago { get; set; }
        public Rol? Rol { get; set; }
    }
}
