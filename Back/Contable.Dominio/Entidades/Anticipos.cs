using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Anticipos
    {

        public int IdAnticipos;
        public required string PorcentajeAnticipo;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;



    }
}
