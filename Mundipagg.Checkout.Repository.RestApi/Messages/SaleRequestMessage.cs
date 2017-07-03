using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mundipagg.Checkout.Repository.RestApi.Messages
{
    public class SaleRequestMessage
    {
		public SaleRequestMessage()
		{
			CreditCardTransactionCollection = new List<CreditCardTransactionCollectionClass>();
		}

		public List<CreditCardTransactionCollectionClass> CreditCardTransactionCollection { get; set; }
		public OrderClass Order { get; set; }

		public class CreditCard
		{
			public string CreditCardBrand { get; set; }
			public string CreditCardNumber { get; set; }
			public int ExpMonth { get; set; }
			public int ExpYear { get; set; }
			public string HolderName { get; set; }
			public string SecurityCode { get; set; }
		}

		public class CreditCardTransactionCollectionClass
		{
			public int AmountInCents { get; set; }
			public CreditCard CreditCard { get; set; }
			public int InstallmentCount { get; set; }
		}

		public class OrderClass
		{
			public string OrderReference { get; set; }
		}
	}
}
