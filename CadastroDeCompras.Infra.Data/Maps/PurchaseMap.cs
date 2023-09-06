using CadastroDeCompras.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroDeCompras.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Idcompra")
                .UseMySqlIdentityColumn();

            builder.Property(x => x.ProductId)
                .HasColumnName("Idproduto");

            builder.Property(x => x.PersonId)
                .HasColumnName("Idpessoa");

            builder.Property(x => x.Date)
                .HasColumnName("Datacompra");

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchases);

        }
    }
}