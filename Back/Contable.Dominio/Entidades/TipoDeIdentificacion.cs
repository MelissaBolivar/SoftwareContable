using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contable.Dominio.Entidades
{
    internal class TipoDeIdentificacion
    {
        public int IdTipoIdentificacion;
        public required string NombreTipoIdentificacion;
        public int IdRol;
        public required DateTime FechaRegistro;
        public required string Estado;

    }
}
