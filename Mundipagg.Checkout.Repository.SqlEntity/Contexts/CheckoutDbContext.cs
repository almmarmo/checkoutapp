using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Repository.SqlEntity.Contexts
{
    public class CheckoutDbContext : DbContext
    {
        public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) : base(options)
        {
            
        }

        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }
        public DbSet<Sale> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasDefaultSchema("Checkout");

            ModelConfigurator config = new ModelConfigurator(modelBuilder);
            config.Configure<AuthenticationTokenConfiguration>()
                .Configure<SaleConfiguration>();
        }
    }
}
