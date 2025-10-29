using Contable.Application.Dtos.Rol;
using Contable.Application.Dtos.TipoDoc;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class TipoDocController(PersistenceContext context) : ControllerBase
    {
        private object? tipodoc;


        // 🔹 GET: api/TipoDoc

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDoc>>> GetTipoDoc()
        {
            var tipodoc = await context.TipoDoc.ToListAsync();
            return Ok(tipodoc);
        }

        // 🔹 GET: api/TipoDoc/5

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDoc>> GetTipoDoc(int id)
        {
            var tipodoc = await context.TipoDoc.FindAsync(id);

            if (tipodoc == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Tipo de Documento con Id = {id}" });
            }

            return Ok(tipodoc);
        }




        // 🔹 POST: api/TipoDoc

        [HttpPost]
        public async Task<ActionResult<TipoDoc>> PostTipoDoc([FromBody] CreateTipoDocDto tipodoc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            TipoDoc tipodocAdd = new()
            {
                
                Nombre = tipodoc.Nombre,
                FechaRegistro = DateTime.UtcNow, // asigna fecha automáticamente
            };



            context.TipoDoc.Add(tipodocAdd);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTipoDoc), new { id = tipodocAdd.TipoDocId }, tipodocAdd);
        }



        // 🔹 PUT: api/TipoDoc

        [HttpPut]
        public async Task<ActionResult<UpdateTipoDocDto>> PutRol([FromBody] UpdateTipoDocDto tipodoc)
        {
            if (tipodoc?.TipoDocId != null)
            {
                var actualizarTipoDoc = await context.TipoDoc.FindAsync(tipodoc.TipoDocId);

                if (actualizarTipoDoc != null)
                {
                    
                    actualizarTipoDoc.Nombre = tipodoc.Nombre;

                    context.TipoDoc.Update(actualizarTipoDoc);
                    await context.SaveChangesAsync();
                    return tipodoc;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el Tipo de Documento con Id = {tipodoc.TipoDocId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar un Tipo de Documento" });
            }
        }

        // 🔹 DELETE: api/Tipo de Identificacion

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoDoc(int id)
        {

            var buscarTipoDoc = await context.TipoDoc.FindAsync(id);

            if (buscarTipoDoc != null)
            {
                context.TipoDoc.Remove(buscarTipoDoc);
                await context.SaveChangesAsync();
                return StatusCode(200, "El Tipo De Documento se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el Tipo De Documento con Id = {id}" });
            }

        }


    }


}

