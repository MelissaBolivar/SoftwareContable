using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Rol
    {
        public int IdRol;
        public required string NombreRol;
        public required string DescripcionRol;
        public required DateTime FechaRegistro;
        public required string Estado;


    }
}
