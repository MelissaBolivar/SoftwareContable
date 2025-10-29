namespace Contable.Application.Dtos.Caja
{
    public class UpdateCajaDto
    {
        public int CajaId { get; set; }
        public decimal Saldo { get; set; }                             // Campo Calculado       
    }
}
