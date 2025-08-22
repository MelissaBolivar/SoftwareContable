using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
     
    internal class Clientes
    {
        public int IdCliente;
        public required string IdTipoIdentificacion;
        public int NumeroIdCliente;
        public required string NombreCliente;
        public required string ApellidoCliente;
        public required string DireccionCliente;
        public required string TelefonoCliente;
        public required string CorreoElectronicoCliente;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}


