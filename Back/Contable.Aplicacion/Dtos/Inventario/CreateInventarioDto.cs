namespace Contable.Application.Dtos.Inventario

{ 
    public class CreateInventarioDto
    {
        public int InventarioId { get; set; }

        public required int UnidadesInventario { get; set; }
        public required int PrecioVentaInventario { get; set; }
        public required int PrecioCompraInventario { get; set; }
    }
}
