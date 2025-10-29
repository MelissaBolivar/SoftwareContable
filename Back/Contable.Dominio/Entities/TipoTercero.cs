using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class TipoTercero
    {
        [Key]
        public int TipoTerceroId { get; set; }
        public  string? Nombre { get; set; }
        public  DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.
        public ICollection<Tercero>? Terceros { get; set; }

    }
}
