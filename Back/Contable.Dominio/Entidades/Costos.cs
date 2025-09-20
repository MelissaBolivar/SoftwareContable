using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Costos
    {
        [Key]
        public int CostosId  { get; set; }
        public int IdProveedor  { get; set; }
        public int IdTipoPago  { get; set; }
        public required int UnidadesCostos  { get; set; }
        public required int PrecioCostos  { get; set; }
        public required DateTime FechaCompraCostos  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }
        public Proveedores? Proveedor { get; set; }
        public TipoDePago? TipoDePago { get; set; }
        public Rol? Rol { get; set; }
    }
}
