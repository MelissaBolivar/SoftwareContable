using Contable.Application.Dtos.Tercero;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TerceroController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public TerceroController(PersistenceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tercero>>> GetTercero()
        {
            var tercero = await _context.Tercero.ToListAsync();
            return Ok(tercero);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tercero>> GetTercero(int id)
        {
            var tercero = await _context.Tercero.FindAsync(id);

            if (tercero == null)
            {
                return NotFound(new { mensaje = $"No se encontró el cliente con Id = {id}" });
            }

            return Ok(tercero);
        }

        [HttpGet("byTipoTercero/{id}")]
        public async Task<ActionResult<IEnumerable<Tercero>>> GetTerceroByTipoTercero(int id)
        {
            var terceros = await _context.Tercero.Where(x => x.TipoTerceroId == id).ToListAsync();

            if (terceros == null || !terceros.Any())
            {
                return NotFound(new { mensaje = $"No se encontraron clientes con TipoTerceroId = {id}" });
            }

            return Ok(terceros);
        }

        [HttpPost]
        public async Task<ActionResult<Tercero>> PostTercero([FromBody] CreateTerceroDto tercero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tercero terceroAdd = new()
            {
                TipoDocId = tercero.TipoDocId,
                TipoTerceroId = tercero.TipoTerceroId,
                NumeroDoc = tercero.NumeroDoc,
                RazonSocialTercero = tercero.RazonSocialTercero,
                DireccionTercero = tercero.DireccionTercero,
                TelefonoTercero = tercero.TelefonoTercero,
                CorreoElectronicoTercero = tercero.CorreoElectronicoTercero,
                FechaRegistro = DateTime.UtcNow,
                Activo = true
            };

            _context.Tercero.Add(terceroAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTercero), new { id = terceroAdd.TerceroId }, terceroAdd);
        }

        [HttpPut]
        public async Task<ActionResult<Tercero>> PutTercero(/*int id,*/ [FromBody] CreateTerceroDto tercero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = tercero.TerceroId.Value;

            var actualizarTercero = await _context.Tercero.FindAsync(id);

            if (actualizarTercero == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Tercero con Id = {id}" });
            }

            actualizarTercero.NumeroDoc = tercero.NumeroDoc;
            actualizarTercero.RazonSocialTercero = tercero.RazonSocialTercero;
            actualizarTercero.DireccionTercero = tercero.DireccionTercero;
            actualizarTercero.TelefonoTercero = tercero.TelefonoTercero;
            actualizarTercero.CorreoElectronicoTercero = tercero.CorreoElectronicoTercero;

            _context.Tercero.Update(actualizarTercero);
            await _context.SaveChangesAsync();

            return Ok(actualizarTercero);
        }

        // Soft-delete vía DELETE (mantener por compatibilidad): marca Activo = false
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTercero(int id)
        {
            var buscarTercero = await _context.Tercero.FindAsync(id);

            if (buscarTercero == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Cliente con Id = {id}" });
            }

            buscarTercero.Activo = false;
            _context.Tercero.Update(buscarTercero);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "El cliente se desactivó correctamente" });
        }

        // Endpoint explícito para desactivar (acepta PUT y PATCH y POST para mayor tolerancia)
        [HttpPatch("deactivate/{id}")]
        [HttpPut("deactivate/{id}")]
        [HttpPost("deactivate/{id}")]
        public async Task<ActionResult> DeactivateTercero(int id)
        {
            var buscarTercero = await _context.Tercero.FindAsync(id);
            if (buscarTercero == null) return NotFound(new { mensaje = $"No se encontró el Cliente con Id = {id}" });

            buscarTercero.Activo = false;
            _context.Tercero.Update(buscarTercero);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "El cliente se desactivó correctamente" });
        }

        // Reactivar (acepta PUT y PATCH y POST)
        [HttpPatch("reactivate/{id}")]
        [HttpPut("reactivate/{id}")]
        [HttpPost("reactivate/{id}")]
        public async Task<ActionResult> ReactivateTercero(int id)
        {
            var buscarTercero = await _context.Tercero.FindAsync(id);

            if (buscarTercero == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Cliente con Id = {id}" });
            }

            buscarTercero.Activo = true;
            _context.Tercero.Update(buscarTercero);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "El cliente se reactivó correctamente" });
        }
    }
}