namespace Contable.Application.Dtos.DetalleServicio
{
    public class UpdateDetalleServicioDto
    {
        public int DetalleServicioId { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}