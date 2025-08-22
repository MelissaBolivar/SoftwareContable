using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Proveedores
    {

        public int IdProveedor;
        public required string IdTipoIdentificacion;
        public int NumeroIdProveedor;
        public required string NombreProveedor;
        public required string ApellidoProveedor;
        public required string DireccionProveedor;
        public required string TelefonoProveedor;
        public required string CorreoElectronicoProveedor;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;


    }
}
