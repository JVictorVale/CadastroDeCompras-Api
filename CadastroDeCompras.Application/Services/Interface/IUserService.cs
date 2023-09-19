using CadastroDeCompras.Application.DTOs;

namespace CadastroDeCompras.Application.Services.Interface
{

    public interface IUserService
    {
        Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
    }
}