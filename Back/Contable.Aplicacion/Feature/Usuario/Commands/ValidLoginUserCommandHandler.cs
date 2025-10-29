using Contable.Application.Dtos.Usuarios;
using Contable.Domain.Services;
using MediatR;

namespace Contable.Application.Feature.Usuario.Commands
{
    public class ValidLoginUserCommandHandler(
        UserService service
    ) : IRequestHandler<ValidLoginUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            ValidLoginUserCommand command,
            CancellationToken cancellationToken
        )
        {
            Domain.Entities.Usuario user = await service.ValidLoginUserAsync(
                command.UserName,
                command.Password
            );

            return MapUserToUserDto(user);
        }

        private static UserDto MapUserToUserDto(Domain.Entities.Usuario user)
        {
            return new UserDto()
            {
                Id = user.UsuarioId,
                Name = user.NombreUsuario
            };
        }
    }
}
