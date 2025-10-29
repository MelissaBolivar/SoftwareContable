using Contable.Application.Dtos.Usuarios;
using MediatR;

namespace Contable.Application.Feature.Usuario.Commands
{
    public record ValidLoginUserCommand(
        string UserName,
        string Password
    ) : IRequest<UserDto>;
}
