namespace Contable.Application.Dtos.DetalleServicio
{
    public class CreateDetalleServicioDto
    {
        public int ServicioId { get; set; }
        public int Unidades { get; set; }
        public decimal Precio { get; set; }
    }
}