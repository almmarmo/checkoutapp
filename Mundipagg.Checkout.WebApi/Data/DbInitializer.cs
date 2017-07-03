using System;
using System.Linq;
using Mundipagg.Checkout.Repository.SqlEntity.Contexts;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CheckoutDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.AuthenticationTokens.Any())
            {
                return;   // DB has been seeded
            }

            var auth = new AuthenticationToken()
            {
                AccessToken  = "lkafjldskjfdsl",
                CustomerKey = "dlskfldjf",
                Name = "teste",
                RefreshToken = "aldkj",
                TokenType = "Tester",
                UserId = Guid.NewGuid(),
                Username = "teste@tester"
            };

            context.AuthenticationTokens.Add(auth);

            context.SaveChanges();

        }
    }
}
