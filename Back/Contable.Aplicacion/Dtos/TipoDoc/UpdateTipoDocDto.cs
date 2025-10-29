namespace Contable.Application.Dtos.TipoDoc
{
    public class UpdateTipoDocDto
    {
        public string TipoDocId { get; set; } = default!;
        public required string Nombre { get; set; }
    }
}
