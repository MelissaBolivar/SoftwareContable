namespace Contable.Application.Dtos.Caja
{
    public class CreateCajaDto
    {
        public int CajaId { get; set; }
        public decimal Saldo { get; set; }                             // Campo Calculado               
    }
}
