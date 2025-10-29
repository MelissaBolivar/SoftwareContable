namespace Contable.Application.Dtos.Anticipo
{
    public class UpdateAnticipoDto
    {
        public int AnticipoId { get; set; }
        public required int PorcentajeAnticipo { get; set; }    // Esto es una propiedad
    }
}
