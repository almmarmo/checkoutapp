using System;
using System.Collections.Generic;
using System.Text;
using Mundipagg.Checkout.Domain;
using Mundipagg.Checkout.Repository.SqlEntity.Contexts;

namespace Mundipagg.Checkout.Repository.SqlEntity
{
    public class SaleRepository : ISaleRepository
    {
        CheckoutDbContext context;
        public SaleRepository(CheckoutDbContext context)
        {
            this.context = context;
        }
        public Sale Save(Sale sale)
        {
            context.Sales.Add(sale);
            context.SaveChanges();

            return sale;
        }
    }
}
