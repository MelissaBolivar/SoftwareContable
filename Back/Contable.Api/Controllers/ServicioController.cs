using Contable.Application.Dtos.Servicio;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public ServicioController(PersistenceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicio()
        {
            var servicios = await _context.Servicio
                .Where(s => s.Activo)
                .ToListAsync();

            return Ok(servicios);
        }

        [HttpGet("desactivados")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetDesactivados()
        {
            var servicios = await _context.Servicio
                .Where(s => !s.Activo)
                .ToListAsync();

            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);

            if (servicio == null)
                return NotFound(new { mensaje = $"No se encontró el servicio con Id = {id}" });

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio([FromBody] CreateServicioDto servicio)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existe = await _context.Servicio
                .AnyAsync(s => s.Codigo == servicio.Codigo);

            if (existe)
                return Conflict(new { mensaje = "Ya existe un servicio con ese código" });

            DateTime fechaLocal;

            try
            {
                fechaLocal = TimeZoneInfo.ConvertTimeFromUtc(
                    DateTime.UtcNow,
                    TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")
                );
            }
            catch
            {
                fechaLocal = DateTime.UtcNow.AddHours(-5);
            }

            Servicio servicioAdd = new()
            {
                Codigo = servicio.Codigo,
                Nombre = servicio.Nombre,
                FechaRegistro = fechaLocal,
                Activo = true
            };

            _context.Servicio.Add(servicioAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServicio), new { id = servicioAdd.ServicioId }, servicioAdd);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateServicioDto>> PutServicio([FromBody] UpdateServicioDto servicio)
        {
            if (servicio?.ServicioId == null)
                return BadRequest(new { mensaje = "Se debe enviar un servicio válido" });

            var actualizarServicio = await _context.Servicio.FindAsync(servicio.ServicioId);

            if (actualizarServicio == null)
                return NotFound(new { mensaje = $"No se encontró el servicio con Id = {servicio.ServicioId}" });

            actualizarServicio.Codigo = servicio.Codigo;
            actualizarServicio.Nombre = servicio.Nombre;

            _context.Servicio.Update(actualizarServicio);
            await _context.SaveChangesAsync();

            return Ok(servicio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);

            if (servicio == null)
                return NotFound(new { mensaje = $"No se encontró el servicio con Id = {id}" });

            if (!servicio.Activo)
                return BadRequest(new { mensaje = "El servicio ya está desactivado" });

            servicio.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Servicio desactivado correctamente" });
        }

        [HttpPut("reactivar/{id}")]
        public async Task<ActionResult> ReactivarServicio(int id)
        {
            var servicio = await _context.Servicio.FindAsync(id);

            if (servicio == null)
                return NotFound(new { mensaje = $"No se encontró el servicio con Id = {id}" });

            if (servicio.Activo)
                return BadRequest(new { mensaje = "El servicio ya está activo" });

            servicio.Activo = true;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Servicio reactivado correctamente" });
        }
    }
}