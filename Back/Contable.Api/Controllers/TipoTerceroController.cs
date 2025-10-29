using Contable.Application.Dtos.TipoTercero;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{



    [ApiController]
    [Route("api/[controller]")]


    public class TipoTerceroController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public TipoTerceroController(PersistenceContext context)
        {
            _context = context;
        }


        // 🔹 GET: api/ TipoTercero

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Entities.TipoTercero>>> GetTipoTercero()
        {
            var tipotercero = await _context.TipoTercero.ToListAsync();
            return Ok(tipotercero);
        }



        // 🔹 GET: api / TipoTercero / 5

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Entities.TipoTercero>> GetTipoTercero(int id)
        {
            var tipotercero = await _context.TipoTercero.FindAsync(id);

            if (tipotercero == null)
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de tercero con Id = {id}" });
            }

            return Ok(tipotercero);
        }

        // 🔹 POST: api / TipoTercero

        [HttpPost]
        public async Task<ActionResult<Domain.Entities.TipoTercero>> PostTipoTercero([FromBody] Application.Dtos.TipoTercero.CreateTipoTerceroDto tipotercero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            Domain.Entities.TipoTercero tipoterceroAdd = new()
            {
                Nombre = tipotercero.Nombre,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente

            };



            _context.TipoTercero.Add(tipoterceroAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoTercero), new { id = tipoterceroAdd.TipoTerceroId }, tipoterceroAdd);
        }


        // 🔹 PUT: api/ TipoTercero

        [HttpPut]
        public async Task<ActionResult<UpdateTipoTerceroDto>> PutRol([FromBody] UpdateTipoTerceroDto tipotercero)
        {
            if (tipotercero?.TipoTerceroId != null)
            {
                var actualizarTipoTercero = await _context.TipoTercero.FindAsync(tipotercero.TipoTerceroId);

                if (actualizarTipoTercero != null)
                {
                    actualizarTipoTercero.Nombre = tipotercero.Nombre;

                    _context.TipoTercero.Update(actualizarTipoTercero);
                    await _context.SaveChangesAsync();
                    return tipotercero;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el tipo de tercero con Id = {tipotercero.TipoTerceroId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar una tipo de tercero" });
            }
        }

        // 🔹 DELETE: api/ TipoTercero

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoTercero(int id)
        {

            var buscarTipoTercero = await _context.TipoTercero.FindAsync(id);

            if (buscarTipoTercero != null)
            {
                _context.TipoTercero.Remove(buscarTipoTercero);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El tipo de tercero se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de tercero con Id = {id}" });
            }

        }



    }
}
