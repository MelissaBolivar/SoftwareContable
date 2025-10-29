using Contable.Application.Dtos.Usuarios;
using MediatR;

namespace Contable.Application.Feature.Usuario.Commands
{
    public record RegisterUserGoogleCommand(
        string UserName
    ) : IRequest<UserDto>;
}
