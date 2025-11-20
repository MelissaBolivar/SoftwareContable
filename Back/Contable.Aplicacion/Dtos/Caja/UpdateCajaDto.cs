namespace Contable.Application.Dtos.Caja
{
    public class UpdateCajaDto
    {
        public int CajaId { get; set; }
        public decimal Saldo { get; set; }

        public string Concepto { get; set; }      
    }
}
