using Contable.Application.Dtos.Usuarios;
using Contable.Application.Feature.Usuario.Commands;
using Contable.Domain.Entities;
using Contable.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController(PersistenceContext context, IMediator mediator) : ControllerBase
    {

        // 🔹 GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            var usuario = await context.Usuario.ToListAsync();
            return Ok(usuario);
        }

        // 🔹 GET: api/usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound(new { mensaje = $"No se encontró el Usuario con Id = {id}" });
            }

            return Ok(usuario);
        }

        // 🔹 POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] CreateUsuarioDto usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }



            Usuario usuarioAdd = new()
            {
                TipoDocId = usuario.TipoDocId,
                RolId = usuario.RolId,

                NumeroDocumentoUsuario = usuario.NumeroDocumentoUsuario,
                NombreUsuario =  usuario.NombreUsuario,
                ApellidoUsuario = usuario.ApellidoUsuario,
                DireccionUsuario = usuario.DireccionUsuario,
                TelefonoUsuario = usuario.TelefonoUsuario,
                CorreoElectronicoUsuario =  usuario.CorreoElectronicoUsuario,
                Password =  usuario.Password
            };



            context.Usuario.Add(usuarioAdd);
            await context.SaveChangesAsync();

            //return usuarioAdd;
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioAdd.UsuarioId }, usuarioAdd);
        }


        // 🔹 PUT: api/usuario
        [HttpPut]
        public async Task<ActionResult<UpdateUsuarioDto>> PutRol([FromBody] UpdateUsuarioDto usuario)
        {
            if (usuario.UsuarioId != null)
            {
                var actualizarUsuario = await context.Usuario.FindAsync(usuario.UsuarioId);

                if (actualizarUsuario != null)
                {
                   
                    actualizarUsuario.NumeroDocumentoUsuario = usuario.NumeroDocumentoUsuario;
                    actualizarUsuario.NombreUsuario = usuario.NombreUsuario;
                    actualizarUsuario.ApellidoUsuario = usuario.ApellidoUsuario;
                    actualizarUsuario.DireccionUsuario = usuario.DireccionUsuario;
                    actualizarUsuario.TelefonoUsuario = usuario.TelefonoUsuario;
                    actualizarUsuario.CorreoElectronicoUsuario = usuario.CorreoElectronicoUsuario;
                    actualizarUsuario.Password = usuario.Password;

                    context.Usuario.Update(actualizarUsuario);
                    await context.SaveChangesAsync();
                    return usuario;
                }
                else
                {
                    return NotFound(new { mensaje = $"No se encontró el Usuario con Id = {usuario.UsuarioId}" });
                }
            }
            else
            {
                return NotFound(new { mensaje = $"Se debe enviar un usuario" });
            }
        }

        // 🔹 DELETE: api/usuario

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(int id)
        {

            var buscarUsuario = await context.Usuario.FindAsync(id);

            if (buscarUsuario != null)
            {
                context.Usuario.Remove(buscarUsuario);
                await context.SaveChangesAsync();
                return StatusCode(200, "El usuario se elimino correctamente");
            }
            else
            {
                return NotFound(new { mensaje = $"No se encontró el Usuario con Id = {id}" });
            }

        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> LoginUserAsync(ValidLoginUserCommand command)
        {
            UserDto userDto = await mediator.Send(command);

            return new OkObjectResult(userDto);
        }

        [HttpPost("registerUserGoogle")]
        public async Task<IActionResult> RegisterUserGoogleAsync(RegisterUserGoogleCommand command)
        {
            UserDto userDto = await mediator.Send(command);

            return new OkObjectResult(userDto);
        }
    }
}






