using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class TipodeDisponible
    {
        [Key]
        public int TipoDisponibleId  { get; set; }
        public required string NombreTipoDisponible  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public ICollection<Tesoreria>? Tesorerias { get; set; }
        public Rol? Rol { get; set; }
    }
}
