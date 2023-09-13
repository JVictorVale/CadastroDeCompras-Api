using CadastroDeCompras.Domain.Repositories;

namespace CadastroDeCompras.Domain.FiltersDb
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string? Name { get; set; }
    }
}