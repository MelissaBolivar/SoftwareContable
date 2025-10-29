namespace Contable.Application.Dtos.Rol
{
    public class UpdateRolDto
    {
        public int RolId { get; set; }

        public required string NombreRol { get; set; }
        public required string DescripcionRol { get; set; }
    }
}
