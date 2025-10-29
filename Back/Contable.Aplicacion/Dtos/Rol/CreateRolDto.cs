namespace Contable.Application.Dtos.Rol
{
    public class CreateRolDto

    {
        public int RolId { get; set; }



        /// <summary>Nombre del rol</summary>
        public string NombreRol { get; set; } = string.Empty;

        /// <summary>Descripción del rol</summary>
        public string DescripcionRol { get; set; } = string.Empty;



        /// <summary>Estado del rol (Activo/Inactivo)</summary>
        public string Estado { get; set; } = "Activo";
    }
}
