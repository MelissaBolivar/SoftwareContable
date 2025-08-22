using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class TipoDePago
    {
        public int IdTipoPago;
        public required string NombreTipoPago;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
