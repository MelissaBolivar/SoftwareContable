namespace Contable.Application.Dtos.TipoDoc
{
    public class CreateTipoDocDto
    {
        public string TipoDocId { get; set; } = default!;
        public required string Nombre { get; set; }
    }
}
