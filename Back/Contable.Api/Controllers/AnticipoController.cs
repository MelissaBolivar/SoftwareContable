using Contable.Application.Dtos.Anticipo;
using Contable.Application.Dtos.Rol;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnticipoController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public AnticipoController(PersistenceContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/Anticipo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anticipo>>> GetAnticipo()
        {
            var anticipo = await _context.Anticipo.ToListAsync();
            return Ok(anticipo);
        }

        // 🔹 GET: api/Anticipo/resumen
        [HttpGet("resumen")]
        public async Task<ActionResult<IEnumerable<object>>> GetAnticipoResumen()
        {
            var anticipos = await _context.Anticipo
                .Where(a => a.Activo == true)
                .Select(a => new {
                    id = a.AnticipoId,
                    nombre = $"{a.PorcentajeAnticipo}%"
                })
                .ToListAsync();

            return Ok(anticipos);
        }

        // 🔹 POST: api/Anticipo
        [HttpPost]
        public async Task<ActionResult<Anticipo>> PostAnticipo([FromBody] CreateAnticipoDto anticipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Anticipo anticipoAdd = new()
            {
                PorcentajeAnticipo = anticipo.PorcentajeAnticipo,
                FechaRegistro = DateTime.UtcNow
            };

            _context.Anticipo.Add(anticipoAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnticipo), new { id = anticipoAdd.AnticipoId }, anticipoAdd);
        }

        // 🔹 PUT: api/Anticipo
        [HttpPut]
        public async Task<ActionResult<UpdateAnticipoDto>> PutRol([FromBody] UpdateAnticipoDto anticipo)
        {
            if (anticipo.AnticipoId != null)
            {
                var actualizarAnticipo = await _context.Anticipo.FindAsync(anticipo.AnticipoId);

                if (actualizarAnticipo != null)
                {
                    actualizarAnticipo.PorcentajeAnticipo = anticipo.PorcentajeAnticipo;

                    _context.Anticipo.Update(actualizarAnticipo);
                    await _context.SaveChangesAsync();
                    return anticipo;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el anticipo con Id = {anticipo.AnticipoId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar un anticipo" });
            }
        }

        // 🔹 DELETE: api/Anticipo/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAnticipo(int id)
        {
            var buscarAnticipo = await _context.Anticipo.FindAsync(id);

            if (buscarAnticipo != null)
            {
                _context.Anticipo.Remove(buscarAnticipo);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El anticipo se eliminó correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el anticipo con Id = {id}" });
            }
        }
    }
}