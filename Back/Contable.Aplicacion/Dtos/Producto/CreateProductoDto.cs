namespace Contable.Application.Dtos.Producto
{
    public class CreateProductoDto
    {
        public int ProductoId { get; set; }

        public required int Codigo { get; set; }
        public required string Nombre { get; set; }
    }
}
