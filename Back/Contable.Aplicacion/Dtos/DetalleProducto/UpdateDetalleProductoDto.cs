namespace Contable.Application.Dtos.DetalleProducto
{
    public class UpdateDetalleProductoDto
    {
        public int DetalleProductoId { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}