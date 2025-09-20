using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId  { get; set; }
        public required string IdTipoIdentificacion  { get; set; }
        public int NumeroIdProveedor  { get; set; }
        public required string NombreProveedor  { get; set; }
        public required string ApellidoProveedor  { get; set; }
        public required string DireccionProveedor  { get; set; }
        public required string TelefonoProveedor  { get; set; }
        public required string CorreoElectronicoProveedor  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public ICollection<Gastos>? Gastos { get; set; }
        public ICollection<Costos>? Costos { get; set; }
        public ICollection<Compras>? Compras { get; set; }

    }
}
