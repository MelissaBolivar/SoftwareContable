using Contable.Application.Dtos.TipoPago;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class TipoPagoController : ControllerBase
    {

        private readonly PersistenceContext _context;

        public TipoPagoController(PersistenceContext context)
        {
            _context = context;
        }


        // 🔹 GET: api/ TipoPago

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPago>>> GetTipoPago()
        {
            var tipopago = await _context.TipoPago.ToListAsync();
            return Ok(tipopago);
        }



        // 🔹 GET: api / TipoPago / 5

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPago>> GetTipoPago(int id)
        {
            var tipopago = await _context.TipoPago.FindAsync(id);

            if (tipopago == null)
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de pago con Id = {id}" });
            }

            return Ok(tipopago);
        }

        // 🔹 POST: api / TipoPago

        [HttpPost]
        public async Task<ActionResult<TipoPago>> PostTipoPago([FromBody] Application.Dtos.TipoPago.CreateTipoPagoDto tipopago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            TipoPago tipopagoAdd = new()
            {
                Nombre = tipopago.Nombre,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente

            };



            _context.TipoPago.Add(tipopagoAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoPago), new { id = tipopagoAdd.TipoPagoId }, tipopagoAdd);
        }


        // 🔹 PUT: api/ TipoPago

        [HttpPut]
        public async Task<ActionResult<UpdateTipoPagoDto>> PutRol([FromBody] UpdateTipoPagoDto tipopago)
        {
            if (tipopago?.TipoPagoId != null)
            {
                var actualizarTipoPago = await _context.TipoPago.FindAsync(tipopago.TipoPagoId);

                if (actualizarTipoPago != null)
                {
                    actualizarTipoPago.Nombre = tipopago.Nombre;

                    _context.TipoPago.Update(actualizarTipoPago);
                    await _context.SaveChangesAsync();
                    return tipopago;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el tipo de pago con Id = {tipopago.TipoPagoId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar una tipo de pago" });
            }
        }

        // 🔹 DELETE: api/ TipoPago

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoPago(int id)
        {

            var buscarTipoPago = await _context.TipoPago.FindAsync(id);

            if (buscarTipoPago != null)
            {
                _context.TipoPago.Remove(buscarTipoPago);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El tipo de pago se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el tipo de pago con Id = {id}" });
            }

        }





    }
}
