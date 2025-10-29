using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class TipoFactura
    {
        [Key]
        public int TipoFacturaId { get; set; }
        public required string Nombre { get; set; }    // Esto es una propiedad
        public required DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.
        public ICollection<Factura>? Facturas { get; set; }    // Relación con Facturas

    }
}
