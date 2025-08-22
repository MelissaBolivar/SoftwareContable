using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Gastos
    {
        public int IdGastos;
        public int IdProveedor;
        public int IdTipoPago;
        public required int UnidadesGastos;
        public required int PrecioGastos;
        public required DateTime FechaCompraGastos;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
