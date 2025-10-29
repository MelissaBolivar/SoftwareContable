using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public int? TipoDocId { get; set; }

        public int? RolId { get; set; }
        public int? NumeroDocumentoUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }

        public string? Password { get; set; }
        public string? DireccionUsuario { get; set; }
        public string? TelefonoUsuario { get; set; }
        public string? CorreoElectronicoUsuario { get; set; }
        public bool IsUserGoogle { get; set; }

        public DateTime? FechaRegistro { get; set; }
        public bool Activo { get; set; }

        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas. 

        public TipoDoc? TipoDoc { get; set; }

        public Rol? Rol { get; set; }
    }
}

