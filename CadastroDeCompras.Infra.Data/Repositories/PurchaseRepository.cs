using CadastroDeCompras.Domain.Entities;
using CadastroDeCompras.Domain.Repositories;
using CadastroDeCompras.Infra.Data.Context;

namespace CadastroDeCompras.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task EditAsync(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}