using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Gastos
    {
        [Key]
        public int GastosId  { get; set; }
        public int IdProveedor  { get; set; }
        public int IdTipoPago  { get; set; }
        public required int UnidadesGastos  { get; set; }
        public required int PrecioGastos  { get; set; }
        public required DateTime FechaCompraGastos  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }
        public Proveedores? Proveedor { get; set; }
        public TipoDePago? TipoDePago { get; set; }
        public Rol? Rol { get; set; }

    }
}
