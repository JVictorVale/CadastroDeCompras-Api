using CadastroDeCompras.Application.DTOs;

namespace CadastroDeCompras.Application.Services.Interface
{

    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
    }
}