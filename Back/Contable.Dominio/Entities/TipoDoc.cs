using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class TipoDoc
    {     

        [Key]
        public int TipoDocId { get; set; } = default!;
        public required string Nombre { get; set; }
        public required DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas. 

        public ICollection<Tercero>? Terceros { get; set; }
        public ICollection<Usuario>? Usuarios { get; set; }

    }
}
