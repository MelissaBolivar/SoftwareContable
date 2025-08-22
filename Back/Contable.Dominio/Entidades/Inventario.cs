using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class Inventario
    {
        public int IdInventario;
        public int IdItem;
        public required int UnidadesInventario;
        public required int PrecioVentaInventario;
        public required int PrecioCompraInventario;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;



    }
}
