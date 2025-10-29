namespace Contable.Application.Dtos.TipoPago
{
    public class UpdateTipoPagoDto
    {
        public int TipoPagoId { get; set; }
        public required string Nombre { get; set; }
    }
}
