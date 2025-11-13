using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Inventario
    {
        [Key]
        public int InventarioId  { get; set; }
        public required int Producto { get; set; }
        public required int Unidades  { get; set; }
        public required int PrecioCompra { get; set; }
        public required int PrecioVenta  { get; set; }
            
        public required DateTime FechaRegistro  { get; set; }
        public bool Activo { get; set; }


        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.  
    }
}

