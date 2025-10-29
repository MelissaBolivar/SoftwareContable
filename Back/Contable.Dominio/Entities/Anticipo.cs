using System.ComponentModel.DataAnnotations;                  // permite usar [Key] para marcar el ID principal

namespace Contable.Domain.Entities
{
    public class Anticipo                  // Porcentaje           
    {
        [Key]
        public int AnticipoId { get; set; }
        public int PorcentajeAnticipo { get; set; }    // Esto es una propiedad
        public required DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.         
        public ICollection<Factura>? Facturas { get; set; }    // Relación con Facturas

    }
}
