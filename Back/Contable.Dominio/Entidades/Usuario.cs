using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId  { get; set; }
        public required int IdTipoIdentificacion  { get; set; }
        public int NumeroIdUsuario  { get; set; }
        public required string NombreUsuario  { get; set; }
        public required string ApellidoUsuario  { get; set; }
        public required string DireccionUsuario  { get; set; }
        public required string TelefonoUsuario  { get; set; }
        public required string CorreoElectronicoUsuario  { get; set; }
        public required string ContrasenaUsuario  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        public TipoDeIdentificacion? TipoIdentificacion { get; set; }
        public Rol? Rol { get; set; }
    }
}
