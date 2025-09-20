using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
     
    public class Clientes
    {
        [Key]
        public int ClientesId  { get; set; }
        public required string IdTipoIdentificacion  { get; set; }
        public int NumeroIdCliente  { get; set; }
        public required string NombreCliente  { get; set; }
        public required string ApellidoCliente  { get; set; }
        public required string DireccionCliente  { get; set; }
        public required string TelefonoCliente  { get; set; }
        public required string CorreoElectronicoCliente  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }


        public Rol? Rol { get; set; }
        public ICollection<Ventas>? Ventas { get; set; }


    }
}


