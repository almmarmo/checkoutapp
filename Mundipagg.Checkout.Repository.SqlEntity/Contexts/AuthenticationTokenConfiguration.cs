using Microsoft.EntityFrameworkCore;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Repository.SqlEntity.Contexts
{
    public class AuthenticationTokenConfiguration : ModelConfigurationBase<AuthenticationToken>
    {
        public AuthenticationTokenConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            Builder.ToTable("AuthenticationToken");
            Builder.HasKey(x => x.Id);

            Builder.Property(x => x.AccessToken)
                .IsRequired()
                .HasMaxLength(255);
            Builder.Property(x => x.CustomerKey)
                .IsRequired()
                .HasMaxLength(255);
            Builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            Builder.Property(x => x.RefreshToken)
                .HasMaxLength(100);
            Builder.Property(x => x.TokenType)
                .IsRequired()
                .HasMaxLength(20);
            Builder.Property(x => x.UserId)
                .IsRequired()
                .HasMaxLength(255);
            Builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
