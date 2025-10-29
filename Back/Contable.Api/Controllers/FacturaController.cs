using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contable.Application.Dtos.Factura;
using System.Text.Json.Serialization;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly PersistenceContext _context;

        public FacturaController(PersistenceContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/factura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDTO>>> GetFactura()
        {
            var facturas = await _context.Factura
                .Include(f => f.Productos)
                    .ThenInclude(dp => dp.Producto)
                .Include(f => f.Servicios)
                    .ThenInclude(ds => ds.Servicio)
                .ToListAsync();

            var resultado = facturas.Select(f => new FacturaDTO
            {
                FacturaId = f.FacturaId,
                Fecha = f.Fecha,
                NumeroFactura = f.NumeroFactura,
                Observaciones = f.Observaciones,
                Total = f.Total,
                TipoPagoId = f.TipoPagoId,
                TipoFacturaId = f.TipoFacturaId,
                AnticipoId = f.AnticipoId,
                TerceroId = f.TerceroId,

                DetalleProducto = f.Productos.Select(p => new DetalleProductoDTO
                {
                    DetalleProductoId = p.DetalleProductoId,
                    ProductoId = p.ProductoId,
                    NombreProducto = p.Producto.Nombre,
                    Unidades = p.Unidades,
                    PrecioUnitario = p.PrecioUnitario
                }).ToList(),

                DetalleServicio = f.Servicios.Select(s => new DetalleServicioDTO
                {
                    DetalleServicioId = s.DetalleServicioId,
                    ServicioId = s.ServicioId,
                    NombreServicio = s.Servicio.Nombre,
                    Unidades = s.Unidades,
                    PrecioUnitario = s.PrecioUnitario
                }).ToList()
            }).ToList();

            return Ok(resultado);
        }


        // 🔹 GET: api/factura/byTipoFactura/2
        [HttpGet("byTipoFactura/{idTipoFactura}")]
        public async Task<ActionResult<IEnumerable<FacturaDTO>>> GetByTipoFactura(int idTipoFactura)
        {
            var facturas = await _context.Factura
                .Include(f => f.Productos)
                    .ThenInclude(dp => dp.Producto)
                .Include(f => f.Servicios)
                    .ThenInclude(ds => ds.Servicio)
                .Where(f => f.TipoFacturaId == idTipoFactura)
                .ToListAsync();

            if (!facturas.Any())
                return NotFound(new { mensaje = $"No se encontraron facturas del tipo {idTipoFactura}" });

            var resultado = facturas.Select(f => new FacturaDTO
            {
                FacturaId = f.FacturaId,
                Fecha = f.Fecha,
                NumeroFactura = f.NumeroFactura,
                Observaciones = f.Observaciones,
                Total = f.Total,
                TipoPagoId = f.TipoPagoId,
                TipoFacturaId = f.TipoFacturaId,
                AnticipoId = f.AnticipoId,
                TerceroId = f.TerceroId,

                DetalleProducto = f.Productos.Select(p => new DetalleProductoDTO
                {
                    DetalleProductoId = p.DetalleProductoId,
                    ProductoId = p.ProductoId,
                    NombreProducto = p.Producto.Nombre,
                    Unidades = p.Unidades,
                    PrecioUnitario = p.PrecioUnitario
                }).ToList(),

                DetalleServicio = f.Servicios.Select(s => new DetalleServicioDTO
                {
                    DetalleServicioId = s.DetalleServicioId,
                    ServicioId = s.ServicioId,
                    NombreServicio = s.Servicio.Nombre,
                    Unidades = s.Unidades,
                    PrecioUnitario = s.PrecioUnitario
                }).ToList()
            }).ToList();

            return Ok(resultado);
        }


        // 🔹 GET: api/factura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _context.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound(new { mensaje = $"No se encontró la factura con Id = {id}" });
            }

            return Ok(factura);
        }

        // 🔹 POST: api/factura
        [HttpPost]
        public async Task<ActionResult> PostFactura([FromBody] CreateFacturaDto factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ((factura.Productos == null || !factura.Productos.Any()) &&
                (factura.Servicios == null || !factura.Servicios.Any()))
            {
                return BadRequest(new { mensaje = "Debes agregar al menos un producto o servicio" });
            }

            try
            {
                var facturaAdd = new Factura
                {
                    TerceroId = factura.TerceroId,
                    TipoPagoId = factura.TipoPagoId,
                    TipoFacturaId = factura.TipoFacturaId,
                    AnticipoId = factura.AnticipoId,
                    Fecha = factura.Fecha,
                    NumeroFactura = factura.NumeroFactura,
                    Observaciones = factura.Observaciones,
                    FechaRegistro = DateTime.UtcNow,
                    CajaId = 1,
                    InventarioId = 1,
                    Total = factura.Total
                };

                _context.Factura.Add(facturaAdd);
                await _context.SaveChangesAsync();

                if (factura.Productos != null)
                {
                    foreach (var item in factura.Productos)
                    {
                        var detalle = new DetalleProducto
                        {
                            FacturaId = facturaAdd.FacturaId,
                            ProductoId = item.ProductoId,
                            Unidades = item.Unidades,
                            PrecioUnitario = item.Precio
                        };
                        _context.DetalleProducto.Add(detalle);
                    }
                }

                if (factura.Servicios != null)
                {
                    foreach (var item in factura.Servicios)
                    {
                        var detalle = new DetalleServicio
                        {
                            FacturaId = facturaAdd.FacturaId,
                            ServicioId = item.ServicioId,
                            Unidades = item.Unidades,
                            PrecioUnitario = item.Precio
                        };
                        _context.DetalleServicio.Add(detalle);
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    mensaje = "Factura creada correctamente",
                    facturaId = facturaAdd.FacturaId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    mensaje = "Error interno al crear la factura",
                    detalle = ex.Message
                });
            }
        }

        // 🔹 PUT: api/factura
        [HttpPut]
        public async Task<ActionResult> Putfactura([FromBody] CreateFacturaDto factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (factura.FacturaId == null)
            {
                return BadRequest(new { mensaje = "Se debe enviar una Factura válida" });
            }

            var actualizarFactura = await _context.Factura.FindAsync(factura.FacturaId);

            if (actualizarFactura == null)
            {
                return NotFound(new { mensaje = $"No se encontró la Factura con Id = {factura.FacturaId}" });
            }

            actualizarFactura.Fecha = factura.Fecha;
            actualizarFactura.NumeroFactura = factura.NumeroFactura;
            actualizarFactura.TerceroId = factura.TerceroId;
            actualizarFactura.TipoPagoId = factura.TipoPagoId;
            actualizarFactura.Observaciones = factura.Observaciones;
            actualizarFactura.AnticipoId = factura.AnticipoId;
            actualizarFactura.Total = factura.Total;

            _context.Factura.Update(actualizarFactura);

            if (factura.Productos != null)
            {
                var facturasAnt = await _context.DetalleProducto
                    .Where(x => x.FacturaId == factura.FacturaId)
                    .ToListAsync();

                _context.DetalleProducto.RemoveRange(facturasAnt);

                foreach (var item in factura.Productos)
                {
                    var detalle = new DetalleProducto
                    {
                        FacturaId = factura.FacturaId,
                        ProductoId = item.ProductoId,
                        Unidades = item.Unidades,
                        PrecioUnitario = item.Precio
                    };
                    await _context.DetalleProducto.AddAsync(detalle);
                }
            }

            if (factura.Servicios != null)
            {
                var facturasAnt = await _context.DetalleServicio
                    .Where(x => x.FacturaId == factura.FacturaId)
                    .ToListAsync();

                _context.DetalleServicio.RemoveRange(facturasAnt);

                foreach (var item in factura.Servicios)
                {
                    var detalle = new DetalleServicio
                    {
                        FacturaId = factura.FacturaId,
                        ServicioId = item.ServicioId,
                        Unidades = item.Unidades,
                        PrecioUnitario = item.Precio
                    };
                    await _context.DetalleServicio.AddAsync(detalle);
                }
            }

            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Factura actualizada correctamente" });
        }

        // 🔹 DELETE: api/factura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFactura(int id)
        {
            var buscarFactura = await _context.Factura.FindAsync(id);

            if (buscarFactura == null)
            {
                return NotFound(new { mensaje = $"No se encontró la factura con Id = {id}" });
            }

            _context.Factura.Remove(buscarFactura);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "La factura se eliminó correctamente" });
        }
    }
}
