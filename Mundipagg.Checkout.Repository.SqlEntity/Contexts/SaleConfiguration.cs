using Microsoft.EntityFrameworkCore;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Repository.SqlEntity.Contexts
{
    public class SaleConfiguration : ModelConfigurationBase<Sale>
    {
        public SaleConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Builder.ToTable("Sale");
            Builder.HasKey(x => x.Id);

            Builder.Property(x => x.AmountInCents).IsRequired();
            Builder.Property(x => x.CreditCardBrand)
                .HasMaxLength(20)
                .IsRequired();
            Builder.Property(x => x.CreditCardNumber)
                .HasMaxLength(20)
                .IsRequired();
            Builder.Property(x => x.Date)
                .IsRequired()
                .HasDefaultValueSql("GetDate()");
            Builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();
            Builder.Property(x => x.HolderName)
                .HasMaxLength(100)
                .IsRequired();
            Builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            Builder.Property(x => x.OrderKey)
                .HasMaxLength(50);
        }
    }
}
