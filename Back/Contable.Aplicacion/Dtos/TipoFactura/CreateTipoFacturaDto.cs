namespace Contable.Application.Dtos.TipoFactura
{
    public class CreateTipoFacturaDto
    {
        public int TipoFacturaId { get; set; }
        public required string Nombre { get; set; }    // Esto es una propiedad
    }
}
