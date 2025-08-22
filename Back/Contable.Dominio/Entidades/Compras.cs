using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Compras
    {
        public int IdCompras;
        public int IdProveedor;
        public int IdTipoPago;
        public required int UnidadesCompra;
        public required int PrecioCompra;
        public required DateTime FechaCompra;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;


    }
}
