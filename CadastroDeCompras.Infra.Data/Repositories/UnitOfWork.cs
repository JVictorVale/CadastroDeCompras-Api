using CadastroDeCompras.Domain.Repositories;
using CadastroDeCompras.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CadastroDeCompras.Infra.Data.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void Dispose()
        {
            _transaction?.Dispose();
        }

        public async Task BeginTransaction()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            await _transaction.RollbackAsync();
        }
    }
}