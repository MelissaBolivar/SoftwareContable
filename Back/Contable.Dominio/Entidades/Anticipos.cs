using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Anticipos
    {
        [Key]
        public int AnticiposId { get; set; }
        public int IdCliente { get; set; }

        public required string PorcentajeAnticipo { get; set; }
        public int IdRol { get; set; }
        public required DateTime FechaRegistro { get; set; }
        public required string Estado { get; set; }

        public Clientes? Cliente { get; set; }
        public Rol? Rol { get; set; }
        public ICollection<Ventas>? Ventas { get; set; }

    }
}
