using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Tesoreria
    {
        public int IdTesoreria;
        public int IdTipoDisponible;
        public int ValorDisponible;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;



    }
}
