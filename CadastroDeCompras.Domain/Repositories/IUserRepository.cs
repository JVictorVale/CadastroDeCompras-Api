using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}