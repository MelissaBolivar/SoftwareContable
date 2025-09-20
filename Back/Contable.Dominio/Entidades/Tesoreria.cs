using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Tesoreria
    {
        [Key]
        public int TesoreriaId  { get; set; }
        public int IdTipoDisponible  { get; set; }
        public int ValorDisponible  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public TipodeDisponible? TipoDisponible { get; set; }
        public Rol? Rol { get; set; }
    }
}
