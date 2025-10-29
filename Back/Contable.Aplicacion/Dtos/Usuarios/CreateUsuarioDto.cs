
namespace Contable.Application.Dtos.Usuarios
{
    public class CreateUsuarioDto
    {
        public int UsuarioId { get; set; }
        public int? TipoDocId { get; set; }

        public int? RolId { get; set; }
        public int? NumeroDocumentoUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }

        public string? DireccionUsuario { get; set; }
        public string? TelefonoUsuario { get; set; }
        public string? CorreoElectronicoUsuario { get; set; }
        public string? Password { get; set; }
        public bool IsUserGoogle { get; set; }

    }
}
