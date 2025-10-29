using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Inventario
    {
        [Key]
        public int InventarioId  { get; set; }


        public required int UnidadesInventario  { get; set; }
        public required int PrecioVentaInventario  { get; set; }
        public required int PrecioCompraInventario  { get; set; }
       
        public required DateTime FechaRegistro  { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.  
        public ICollection<Factura>? Facturas { get; set; }    // Relación con Facturas
    }
}
