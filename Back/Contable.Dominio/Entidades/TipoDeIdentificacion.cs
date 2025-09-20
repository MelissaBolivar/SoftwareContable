using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class TipoDeIdentificacion
    {
        [Key]
        public int TipoIdentificacionId  { get; set; }
        public required string NombreTipoIdentificacion  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Proveedores>? Proveedores { get; set; }
        public Rol? Rol { get; set; }
    }
}
