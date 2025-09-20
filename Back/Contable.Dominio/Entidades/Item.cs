using System.ComponentModel.DataAnnotations;

namespace Contable.Domain.Entidades
{
    public class Item
    {
        [Key]
        public int ItemId  { get; set; }
        public required string NombreItem  { get; set; }
        public int IdRol  { get; set; }
        public required DateTime FechaRegistro  { get; set; }
        public required string Estado { get; set; }

        // 🔹 Navegación inversa
        public ICollection<Inventario>? Inventarios { get; set; }
        public Rol? Rol { get; set; }
    }
}
