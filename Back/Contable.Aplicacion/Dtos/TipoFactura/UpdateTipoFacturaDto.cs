namespace Contable.Application.Dtos.TipoFactura
{
    public class UpdateTipoFacturaDto
    {
        public int TipoFacturaId { get; set; }
        public required string Nombre { get; set; }    // Esto es una propiedad
    }
}
