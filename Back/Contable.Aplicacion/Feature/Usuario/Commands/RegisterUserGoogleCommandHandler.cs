using Contable.Application.Dtos.Usuarios;
using Contable.Domain.Services;
using MediatR;

namespace Contable.Application.Feature.Usuario.Commands
{
    public class RegisterUserGoogleCommandHandler(
        UserService service
    ) : IRequestHandler<RegisterUserGoogleCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            RegisterUserGoogleCommand command,
            CancellationToken cancellationToken
        )
        {
            Contable.Domain.Entities.Usuario user = await service.RegisterUserGoogleAsync(
                command.UserName,
                true
            );

            return MapUserToUserDto(user);
        }

        private static UserDto MapUserToUserDto(Contable.Domain.Entities.Usuario user)
        {
            return new UserDto()
            {
                Id = user.UsuarioId,
                Name = user.NombreUsuario
            };
        }
    }
}
