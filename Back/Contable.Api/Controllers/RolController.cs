using Contable.Domain.Entidades;
using Contable.Infrastructure.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public RolController(PersistenceContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            var roles = await _context.Rol.ToListAsync();
            return Ok(roles);
        }

        // 🔹 GET: api/rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rol.FindAsync(id);

            if (rol == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Rol con Id = {id}" });
            }

            return Ok(rol);
        }

        // 🔹 POST: api/rol
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol([FromBody] CreateRolDto rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            Rol rolAdd = new() { 
                NombreRol = rol.NombreRol,
                DescripcionRol = rol.DescripcionRol,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente
                Estado = rol.Estado
            };



            _context.Rol.Add(rolAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rolAdd.RolId }, rolAdd);
        }
    }

    public class CreateRolDto
    {
        /// <summary>Nombre del rol</summary>
        public string NombreRol { get; set; } = string.Empty;

        /// <summary>Descripción del rol</summary>
        public string DescripcionRol { get; set; } = string.Empty;

        /// <summary>Estado del rol (Activo/Inactivo)</summary>
        public string Estado { get; set; } = "Activo";
    }
}
