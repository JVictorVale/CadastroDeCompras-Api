using CadastroDeCompras.Application.DTOs;

namespace CadastroDeCompras.Application.Services.Interface
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
    }
}