namespace Contable.Application.Dtos.Inventario
{
    public class UpdateInventarioDto
    {
        public int InventarioId { get; set; }
        public required int Producto { get; set; }
        public required int Unidades { get; set; }
        public required int PrecioCompra { get; set; }
        public required int PrecioVenta { get; set; }
    }
}