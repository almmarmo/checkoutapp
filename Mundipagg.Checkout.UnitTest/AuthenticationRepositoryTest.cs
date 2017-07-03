using System;
using Mundipagg.Checkout.Repository.RestApi;
using Mundipagg.Checkout.Repository.RestApi.Messages;
using Xunit;

namespace Mundipagg.Checkout.UnitTest
{
	public class AuthenticationRepositoryTest
	{
		[Fact]
		public void SignInTest()
		{
			AuthenticationRepository r = new AuthenticationRepository();
			var user = r.SignIn("teste", "123456");
			Console.WriteLine(user.CustomerKey);
		}

		[Fact]
		public void Sale()
		{
			MundipaggApiClient a = new MundipaggApiClient();
			var request = new SaleRequestMessage();
			request.Order = new SaleRequestMessage.OrderClass()
			{
				OrderReference = "123456667788"
			};
			request.CreditCardTransactionCollection.Add(new SaleRequestMessage.CreditCardTransactionCollectionClass()

			{
				AmountInCents = 100,
				InstallmentCount = 1,
				CreditCard = new SaleRequestMessage.CreditCard()
				{
					CreditCardBrand = "Visa",
					CreditCardNumber = "4111111111111111",
					ExpMonth = 10,
					ExpYear = 22,
					HolderName = "LUKE SKYWALKER",
					SecurityCode = "123"
				}
			});
			var response = a.Sale("383a9afe-28ca-44a6-a702-5d12280649b1", request);
		}

	}
}
