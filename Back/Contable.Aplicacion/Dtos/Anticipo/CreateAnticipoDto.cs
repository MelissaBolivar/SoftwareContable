namespace Contable.Application.Dtos.Anticipo
{
    public class CreateAnticipoDto
    {
        public int AnticipoId { get; set; }
        public required int PorcentajeAnticipo { get; set; }    // Esto es una propiedad        
    }
}
