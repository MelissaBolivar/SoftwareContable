

using Contable.Application.Dtos.Inventario;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class InventarioController : ControllerBase
    {

        private readonly PersistenceContext _context;

        public InventarioController(PersistenceContext context)
        {
            _context = context;
        }


        // 🔹 GET: api/Inventario

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventario()
        {
            var inventario = await _context.Inventario.ToListAsync();
            return Ok(inventario);
        }

        // 🔹 GET: api/inventario/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _context.Inventario.FindAsync(id);

            if (inventario == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Inventario con Id = {id}" });
            }

            return Ok(inventario);
        }

        // 🔹 POST: api/ inventario

        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario([FromBody] CreateInventarioDto inventario)
        {
            ArgumentNullException.ThrowIfNull(inventario);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            Inventario inventarioAdd = new()
            {             
                UnidadesInventario = inventario.UnidadesInventario,
                PrecioVentaInventario = inventario.PrecioVentaInventario, 
                PrecioCompraInventario= inventario.PrecioCompraInventario,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente

            };


            try
            {
                _context.Inventario.Add(inventarioAdd);
                await _context.SaveChangesAsync();
            }catch(Exception e)
            {
                var a = 1;
            }
            return CreatedAtAction(nameof(GetInventario), new { id = inventarioAdd.InventarioId }, inventarioAdd);
        }


        // 🔹 PUT: api/ Inventario

        [HttpPut]
        public async Task<ActionResult<UpdateInventarioDto>> PutInventario([FromBody] UpdateInventarioDto inventario)
        {
            if (inventario.InventarioId != null)
            {
                var actualizarInventario = await _context.Inventario.FindAsync(inventario.InventarioId);

                if (actualizarInventario != null)
                {
                    actualizarInventario.UnidadesInventario = inventario.UnidadesInventario;
                    actualizarInventario.PrecioVentaInventario = inventario.PrecioVentaInventario;
                    actualizarInventario.PrecioCompraInventario = inventario.PrecioCompraInventario;

                    _context.Inventario.Update(actualizarInventario);
                    await _context.SaveChangesAsync();
                    return inventario;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el Inventario con Id = {inventario.InventarioId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar un inventario" });
            }
        }

        // 🔹 DELETE: api/ Inventario

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventario(int id)
        {

            var buscarInventario = await _context.Inventario.FindAsync(id);

            if (buscarInventario != null)
            {
                _context.Inventario.Remove(buscarInventario);
                await _context.SaveChangesAsync();
                return StatusCode(200, "El Inventario se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el Inventario con Id = {id}" });
            }

        }




    }

}

   
