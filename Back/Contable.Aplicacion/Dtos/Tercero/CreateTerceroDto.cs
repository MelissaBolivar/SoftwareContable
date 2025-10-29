namespace Contable.Application.Dtos.Tercero
{
    public class CreateTerceroDto
    {
        public int? TerceroId { get; set; } // Es el identificador invisible de cada tercero.
        public required int TipoDocId { get; set; }  // puede ser cc - nit - pasaporte - CE - en lista desplegable para elegir.
        public required int TipoTerceroId { get; set; } // Proveedor - Clientes - Empleado, en lista desplegable para elegir.

        // Estos son los campos que voy a visualizar en el front-end

        public int NumeroDoc { get; set; }
        public required string RazonSocialTercero { get; set; } // Solo se activa si el tipo de tercero es NIT.
        public required string DireccionTercero { get; set; }
        public required string TelefonoTercero { get; set; }
        public required string CorreoElectronicoTercero { get; set; }
    }
}
