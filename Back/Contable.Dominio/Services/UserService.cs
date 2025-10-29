using Contable.Domain.Entities;
using Contable.Domain.Exceptions;
using Contable.Domain.Ports;

namespace Contable.Domain.Services
{
    [DomainService]
    public class UserService(
        IGenericRepository<Usuario> userRepository
    )
    {
        public async Task<Usuario> CreateUserAsync(
            string name,
            string userName,
            string password
        )
        {

            Usuario User = new()
            {
                NombreUsuario = name,
                Password = password
            };

            User = await userRepository.AddAsync(User);

            return User;
        }

        public async Task<Usuario> UpdateUserAsync(
            int id,
            string name,
            string userName,
            string? password
        )
        {
            Usuario User = await GetUserById(id);

            User.NombreUsuario = name;
            User.Password = userName;

            if (password != null)
            {
                User.Password = password;
            }

            User = await userRepository.UpdateAsync(User);

            return User;
        }

        public async Task<Usuario> ValidLoginUserAsync(
            string userName,
            string password
        )
        {
            Usuario? user = (await userRepository.GetAsync(user => user.NombreUsuario == userName && user.Password == password)).FirstOrDefault();

            return user ?? throw new AppException("Credenciales invalidas");
        }

        public async Task<Usuario> RegisterUserGoogleAsync(
            string userName,
            bool IsUserGoogle
        )
        {
            var listUser = (await userRepository.GetAsync(x => x.NombreUsuario == userName)).ToList();

            if (listUser.Count != 0)
            {
                return listUser.FirstOrDefault()!;
            }

            Usuario user = new()
            {
                NombreUsuario = userName,
                IsUserGoogle = IsUserGoogle
            };

            user = await userRepository.AddAsync(user);

            return user;
        }

        public async Task<Usuario> GetUserById(int id)
        {
            Usuario? User = await userRepository.GetByIdAsync(id);

            return User ?? throw new AppException("No existe el usuario");
        }
    }
}
