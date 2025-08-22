using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Item
    {
        public int IdItem;
        public required string NombreItem;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
