namespace CadastroDeCompras.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task RollBack();
    }
}