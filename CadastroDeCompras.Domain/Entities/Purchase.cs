using CadastroDeCompras.Domain.Validation;

namespace CadastroDeCompras.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }


        public Purchase(int productId, int personId, DateTime date)
        {
            Validation(productId, personId, date);
        }

        public Purchase(int id, int productId, int personId, DateTime date, Person person, Product product)
        {
            DomainValidationException.When(id < 0, "O Id deve ser informado!");
            Id = id;
            Validation(productId, personId, date);
        }

        public void Validation(int produtId, int personId, DateTime? date)
        {
            DomainValidationException.When(produtId < 0, "Id produto deve ser informado!");
            DomainValidationException.When(personId < 0, "Id pessoa deve ser informado!");
            DomainValidationException.When(date.HasValue, "Data da compra deve ser informada!");

            ProductId = produtId;
            PersonId = personId;
            Date = date.Value;
        }
        
    }
}