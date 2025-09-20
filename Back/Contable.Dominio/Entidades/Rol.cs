using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Rol
    {
        [Key]
        public int RolId  { get; set; }
        public required string NombreRol  { get; set; }
        public required string DescripcionRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public ICollection<Gastos>? Gastos { get; set; }
        public ICollection<Costos>? Costos { get; set; }
        public ICollection<Compras>? Compras { get; set; }
        public ICollection<Clientes>? Clientes { get; set; }
        public ICollection<Anticipos>? Anticipos { get; set; }

    }
}
