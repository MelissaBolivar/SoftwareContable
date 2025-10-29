using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Caja
    {
        [Key]
        public int CajaId { get; set; }
        public decimal Saldo { get; set; }                             // Campo Calculado       
        public required DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.

        public ICollection<Factura>? Facturas { get; set; }    // Relación con Facturas
    }
}
