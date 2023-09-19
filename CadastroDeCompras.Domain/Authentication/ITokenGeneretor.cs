using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Domain.Authentication
{
    public interface ITokenGeneretor
    {
        dynamic Generator(User user);
    }
}