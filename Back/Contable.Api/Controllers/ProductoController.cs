using Contable.Application.Dtos.Producto;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public ProductoController(PersistenceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            var productos = await _context.Producto
                .Where(p => p.Activo)
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet("desactivados")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetDesactivados()
        {
            var productos = await _context.Producto
                .Where(p => !p.Activo)
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
                return NotFound(new { mensaje = $"No se encontró el producto con Id = {id}" });

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto([FromBody] CreateProductoDto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existe = await _context.Producto
                .AnyAsync(p => p.Codigo == producto.Codigo);

            if (existe)
                return Conflict(new { mensaje = "Ya existe un producto con ese código" });

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

            Producto productoAdd = new()
            {
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                FechaRegistro = fechaLocal,
                Activo = true
            };

            _context.Producto.Add(productoAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = productoAdd.ProductoId }, productoAdd);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateProductoDto>> PutProducto([FromBody] UpdateProductoDto producto)
        {
            if (producto?.ProductoId == null)
                return BadRequest(new { mensaje = "Se debe enviar un producto válido" });

            var actualizarProducto = await _context.Producto.FindAsync(producto.ProductoId);

            if (actualizarProducto == null)
                return NotFound(new { mensaje = $"No se encontró el producto con Id = {producto.ProductoId}" });

            actualizarProducto.Codigo = producto.Codigo;
            actualizarProducto.Nombre = producto.Nombre;

            _context.Producto.Update(actualizarProducto);
            await _context.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
                return NotFound(new { mensaje = $"No se encontró el producto con Id = {id}" });

            if (!producto.Activo)
                return BadRequest(new { mensaje = "El producto ya está desactivado" });

            producto.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto desactivado correctamente" });
        }

        [HttpPut("reactivar/{id}")]
        public async Task<ActionResult> ReactivarProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
                return NotFound(new { mensaje = $"No se encontró el producto con Id = {id}" });

            if (producto.Activo)
                return BadRequest(new { mensaje = "El producto ya está activo" });

            producto.Activo = true;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Producto reactivado correctamente" });
        }
    }
}