namespace Contable.Application.Dtos.DetalleProducto
{
    public class CreateDetalleProductoDto
    {
        public int ProductoId { get; set; }
        public int Unidades { get; set; }
        public decimal Precio { get; set; }
    }
}