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
        public async Task<ActionResult<IEnumerable<object>>> GetInventarioConProducto()
        {
            // 1️⃣ Traemos los últimos registros de inventario por producto
            var ultimosInventarios = await _context.Inventario
                .Where(x => x.Activo)
                .GroupBy(x => x.Producto)
                .Select(g => g
                    .OrderByDescending(x => x.FechaRegistro)
                    .FirstOrDefault()
                )
                .ToListAsync(); // ✅ aquí usamos ToListAsync, await funciona

            // 2️⃣ Hacemos el join con producto en memoria
            var resultado = ultimosInventarios
                .Join(
                    _context.Producto.Where(p => p.Activo).AsEnumerable(), // producto en memoria
                    inv => inv.Producto,
                    prod => prod.ProductoId,
                    (inv, prod) => new
                    {
                        inv.InventarioId,
                        inv.Producto,
                        prod.Codigo,
                        prod.Nombre,
                        inv.Unidades,
                        inv.PrecioCompra,
                        inv.PrecioVenta,
                        inv.FechaRegistro
                    }
                )
                .ToList();

            return Ok(resultado);
        }


    }

}
