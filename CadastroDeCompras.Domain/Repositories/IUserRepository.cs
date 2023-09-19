using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}