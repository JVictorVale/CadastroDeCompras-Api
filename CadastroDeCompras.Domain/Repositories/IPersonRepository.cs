using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<ICollection<Person>> GetPeopleAsync();
    Task<Person> CreateAsync(Person person);
    Task EditAsync(Person person);
    Task DeleteAsync(Person person);
    Task<int> GetIdByDocumentAsync(string document);
}