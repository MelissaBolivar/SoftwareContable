using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entities
{

    public class Tercero

    // Estas son las llaves o entiedades que se relacionan entre si.

    {
        [Key]
        public int TerceroId { get; set; } // Es el identificador invisible de cada tercero.
        public required int TipoDocId { get; set; }  // puede ser cc - nit - pasaporte - CE - en lista desplegable para elegir.
        public required int TipoTerceroId { get; set; } // Proveedor - Clientes - Empleado, en lista desplegable para elegir.

        // Estos son los campos que voy a visualizar en el front-end

        public int NumeroDoc { get; set; }
        public required string RazonSocialTercero { get; set; } // Solo se activa si el tipo de tercero es NIT.
        public required string DireccionTercero { get; set; }
        public required string TelefonoTercero { get; set; }
        public required string CorreoElectronicoTercero { get; set; }
        public required DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        // propiedades de Navegacion, sirve para relacionarse las tablas entre ellas.


        public TipoDoc? TipoDoc { get; set; }
        public TipoTercero? TipoTercero { get; set; }
        public ICollection<Factura>? Facturas { get; set; }
    }
}


