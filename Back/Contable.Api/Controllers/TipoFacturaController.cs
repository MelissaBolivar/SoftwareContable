using Contable.Application.Dtos.TipoFactura;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TipoFacturaController : ControllerBase
    {

        private readonly PersistenceContext _context;

        public TipoFacturaController(PersistenceContext context)
        {
            _context = context;
        }


        // 🔹 GET: api/ TipoFactura

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFactura>>> GetTipoFactura()
        {
            var tipofactura = await _context.TipoFactura.ToListAsync();
            return Ok(tipofactura);
        }



        // 🔹 GET: api / TipoFactura / 5

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFactura>> GetTipoFactura(int id)
        {
            var tipofactura = await _context.TipoFactura.FindAsync(id);

            if (tipofactura == null)
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de factura con Id = {id}" });
            }

            return Ok(tipofactura);
        }

        // 🔹 POST: api / TipoFactura

        [HttpPost]
        public async Task<ActionResult<TipoFactura>> PostTipoFactura([FromBody] Application.Dtos.TipoFactura.CreateTipoFacturaDto tipofactura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            TipoFactura tipofacturaAdd = new()
            {
                Nombre = tipofactura.Nombre,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente

            };



            _context.TipoFactura.Add(tipofacturaAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoFactura), new { id = tipofacturaAdd.TipoFacturaId }, tipofacturaAdd);
        }


        // 🔹 PUT: api/ TipoFactura

        [HttpPut]
        public async Task<ActionResult<UpdateTipoFacturaDto>> PutRol([FromBody] UpdateTipoFacturaDto tipofactura)
        {
            if (tipofactura?.TipoFacturaId != null)
            {
                var actualizarTipoFactura = await _context.TipoFactura.FindAsync(tipofactura.TipoFacturaId);

                if (actualizarTipoFactura != null)
                {
                    actualizarTipoFactura.Nombre = tipofactura.Nombre;

                    _context.TipoFactura.Update(actualizarTipoFactura);
                    await _context.SaveChangesAsync();
                    return tipofactura;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el tipo de factura con Id = {tipofactura.TipoFacturaId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar una tipo de factura" });
            }
        }

        // 🔹 DELETE: api/ TipoFactura

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoFactura(int id)
        {

            var buscarTipoFactura = await _context.TipoFactura.FindAsync(id);

            if (buscarTipoFactura != null)
            {
                _context.TipoFactura.Remove(buscarTipoFactura);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El tipo de factura se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de factura con Id = {id}" });
            }

        }





    }
}
