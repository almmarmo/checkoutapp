using System;

namespace Mundipagg.Checkout.Domain
{
	public class Sale
    {
        public Sale() { }

        public Sale(CheckoutOrder checkout) : this()
        {
            Name = checkout.Name;
            Email = checkout.Email;
            CreditCardNumber = checkout.CreditCardNumber;
            CreditCardBrand = checkout.CreditCardFlag;
            HolderName = checkout.NameOnCreditCard;
            AmountInCents = Convert.ToInt32(checkout.TransactionValue * 100);
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public string HolderName { get; set; }
        public string CreditCardBrand { get; set; }
        public int AmountInCents { get; set; }
		public DateTime Date { get; set; }
        public string OrderKey { get; set; }
    }
}
