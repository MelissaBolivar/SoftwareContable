using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class TipoPago
    {
        [Key]
        public int TipoPagoId  { get; set; }
        public required string Nombre  { get; set; }  
        public required DateTime FechaRegistro  { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.
        public ICollection<Factura>? Facturas { get; set; }


    }
}
