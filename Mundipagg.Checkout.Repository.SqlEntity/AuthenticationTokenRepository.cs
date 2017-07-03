using System;
using System.Collections.Generic;
using System.Text;
using Mundipagg.Checkout.Domain;
using Mundipagg.Checkout.Repository.SqlEntity.Contexts;

namespace Mundipagg.Checkout.Repository.SqlEntity
{
    public class AuthenticationTokenRepository : IAuthenticationTokenRepository
    {
        CheckoutDbContext context;
        public AuthenticationTokenRepository(CheckoutDbContext context)
        {
            this.context = context;
        }
        public void Save(AuthenticationToken authenticationToken)
        {
            context.AuthenticationTokens.Add(authenticationToken);
            context.SaveChanges();
        }
    }
}
