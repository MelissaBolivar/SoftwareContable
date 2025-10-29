namespace Contable.Application.Dtos.TipoPago
{
    public class CreateTipoPagoDto
    {
        public int TipoPagoId { get; set; }
        public required string Nombre { get; set; }
    }
}
