using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Application
{
    public class SaleView
    {
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
