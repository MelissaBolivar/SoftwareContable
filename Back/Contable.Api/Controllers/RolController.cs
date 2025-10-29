using Contable.Application.Dtos.Rol;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
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

        // 🔹 GET: api/rol/5<

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



            Rol rolAdd = new()
            {
                NombreRol = rol.NombreRol,
                DescripcionRol = rol.DescripcionRol,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente
            };



            _context.Rol.Add(rolAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRol), new { id = rolAdd.RolId }, rolAdd);
        }


        // 🔹 PUT: api/rol

        [HttpPut]
        public async Task<ActionResult<UpdateRolDto>> PutRol([FromBody] UpdateRolDto rol)
        {
            if (rol.RolId != null)
            {
                var actualizarRol = await _context.Rol.FindAsync(rol.RolId);

                if (actualizarRol != null)
                {
                    actualizarRol.NombreRol = rol.NombreRol;
                    actualizarRol.DescripcionRol = rol.DescripcionRol;

                    _context.Rol.Update(actualizarRol);
                    await _context.SaveChangesAsync();
                    return rol;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el Rol con Id = {rol.RolId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar un rol" });
            }
        }

        // 🔹 DELETE: api/rol

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(int id)
        {

            var buscarRol = await _context.Rol.FindAsync(id);

            if (buscarRol != null)
            {
                _context.Rol.Remove(buscarRol);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El rol se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el Rol con Id = {id}" });
            }

        }




    }

}
