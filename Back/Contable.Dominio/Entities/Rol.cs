using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Rol
    {
        [Key]
        public int RolId  { get; set; }

        public required string NombreRol  { get; set; }
        public required string DescripcionRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public bool Activo { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}
