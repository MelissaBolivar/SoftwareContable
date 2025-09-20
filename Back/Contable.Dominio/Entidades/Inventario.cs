using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Inventario
    {
        [Key]
        public int InventarioId  { get; set; }
        public int IdItem  { get; set; }
        public required int UnidadesInventario  { get; set; }
        public required int PrecioVentaInventario  { get; set; }
        public required int PrecioCompraInventario  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        // 🔹 Navegación
        public Item? Item { get; set; }
        public Rol? Rol { get; set; }
    }
}
