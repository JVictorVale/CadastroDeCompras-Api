using CadastroDeCompras.Application.DTOs;

namespace CadastroDeCompras.Application.Services.Interface
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO);
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<ProductDTO>>> GetAsync();
    }
}