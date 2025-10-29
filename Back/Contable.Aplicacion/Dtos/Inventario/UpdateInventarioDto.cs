namespace Contable.Application.Dtos.Inventario
{
    public class UpdateInventarioDto
    {
        public int InventarioId { get; set; }


        public required int UnidadesInventario { get; set; }
        public required int PrecioVentaInventario { get; set; }
        public required int PrecioCompraInventario { get; set; }

    }
}
