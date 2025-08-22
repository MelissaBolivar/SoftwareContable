using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Costos
    {
        public int IdCostos;
        public int IdProveedor;
        public int IdTipoPago;
        public required int UnidadesCostos;
        public required int PrecioCostos;
        public required DateTime FechaCompraCostos;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
