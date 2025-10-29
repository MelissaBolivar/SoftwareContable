using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contable.Domain.Entities
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        public required int Codigo { get; set; }

        public required string Nombre { get; set; }

        [Column(TypeName = "datetime")]
        public required DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        public ICollection<Factura>? Facturas { get; set; }
    }
}