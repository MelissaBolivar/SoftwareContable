using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Usuario
    {
        public int IdUsuario;
        public required string IdTipoIdentificacion;
        public int NumeroIdUsuario;
        public required string NombreUsuario;
        public required string ApellidoUsuario;
        public required string DireccionUsuario;
        public required string TelefonoUsuario;
        public required string CorreoElectronicoUsuario;
        public required string ContrasenaUsuario;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;



    }
}
