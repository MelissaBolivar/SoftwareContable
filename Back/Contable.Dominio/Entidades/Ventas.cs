using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Ventas
    {
        public int IdVenta;
        public int IdCliente;
        public int IdTipoPago;
        public int IdAnticipo;
        public required int UnidadesVenta;
        public required int PrecioVenta;
        public required DateTime FechaVenta;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
