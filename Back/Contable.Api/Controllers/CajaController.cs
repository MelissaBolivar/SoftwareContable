using Contable.Application.Dtos.Caja;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]

    public class CajaController : ControllerBase
    {

        private readonly PersistenceContext _context;

        public CajaController(PersistenceContext context)
        {
            _context = context;
        }


        // 🔹 GET: api/ Caja

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetCaja()
        {
            // 1️⃣ Traemos los últimos registros de inventario por producto
            var ultimosRegistroCaja = await _context.Caja
                .Where(x => x.Activo)
                .OrderByDescending(x => x.FechaRegistro)                
                .ToListAsync(); // ✅ aquí usamos ToListAsync, await funciona            

            return Ok(ultimosRegistroCaja);
        }




        // 🔹 GET: api / Caja / 5

        [HttpGet("{id}")]
        public async Task<ActionResult<Caja>> GetCaja(int id)
        {
            var caja = await _context.Caja.FindAsync(id);

            if (caja == null)
            {
                return NotFound(new { mensaje = $"No se encontró la caja con Id = {id}" });
            }

            return Ok(caja);
        }

        // 🔹 POST: api / Caja

        [HttpPost]
        public async Task<ActionResult<Caja>> PostCaja([FromBody] Application.Dtos.Caja.CreateCajaDto caja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            Caja cajaAdd = new()
            {
                Saldo = caja.Saldo,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente
            };



            _context.Caja.Add(cajaAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCaja), new { id = cajaAdd.CajaId }, cajaAdd);
        }


        // 🔹 PUT: api/ Caja

        [HttpPut]
        public async Task<ActionResult<UpdateCajaDto>> PutRol([FromBody] UpdateCajaDto caja)
        {
            if (caja?.CajaId != null)
            {
                var actualizarCaja = await _context.Caja.FindAsync(caja.CajaId);

                if (actualizarCaja != null)
                {
                    actualizarCaja.Saldo = caja.Saldo;

                    _context.Caja.Update(actualizarCaja);
                    await _context.SaveChangesAsync();
                    return caja;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró la caja con Id = {caja.CajaId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar una caja" });
            }
        }

        // 🔹 DELETE: api/ Caja

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCaja(int id)
        {

            var buscarCaja = await _context.Caja.FindAsync(id);

            if (buscarCaja != null)
            {
                _context.Caja.Remove(buscarCaja);
                await _context.SaveChangesAsync();
                return StatusCode(200, "La caja se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró la caja con Id = {id}" });
            }

        }


    }
}
