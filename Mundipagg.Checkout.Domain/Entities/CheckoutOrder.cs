using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Domain
{
    public class CheckoutOrder
    {
		public string Name { get; set; }
		public string Email { get; set; }
		public string CreditCardNumber { get; set; }
		public string NameOnCreditCard { get; set; }
        public short ExpirationMonth { get; set; }
        public short ExpirationYear { get; set; }
		public string CreditCardFlag { get; set; }
		public string SecurityCode { get; set; }
		public decimal TransactionValue { get; set; }
        public string MerchantId { get; set; }
	}
}
