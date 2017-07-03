using System;
using Mundipagg.Checkout.Domain;
using Mundipagg.Checkout.Repository.RestApi.Messages;

namespace Mundipagg.Checkout.Repository.RestApi
{
    public class CheckoutRepository : ICheckoutRepository
    {
        public Sale Checkout(CheckoutOrder checkoutOrder)
        {
            Sale sale = null;
            if(checkoutOrder != null)
            { 
            SaleRequestMessage request = new SaleRequestMessage()
            {
                Order = new SaleRequestMessage.OrderClass() { OrderReference=Guid.NewGuid().ToString()}
            };
            request.CreditCardTransactionCollection.Add(new SaleRequestMessage.CreditCardTransactionCollectionClass()
            {
                AmountInCents = Convert.ToInt32(checkoutOrder.TransactionValue * 100),
                InstallmentCount = 1,
                CreditCard = new SaleRequestMessage.CreditCard()
                {
                    CreditCardBrand = checkoutOrder.CreditCardFlag,
                    CreditCardNumber = checkoutOrder.CreditCardNumber,
                    ExpMonth = checkoutOrder.ExpirationMonth,
                    ExpYear = checkoutOrder.ExpirationYear,
                    HolderName = checkoutOrder.NameOnCreditCard,
                    SecurityCode = checkoutOrder.SecurityCode
                }
            });
                using (MundipaggApiClient client = new MundipaggApiClient())
                {
                    var response = client.Sale(checkoutOrder.MerchantId, request);
                    if (response.CreditCardTransactionResultCollection != null)
                    {
                        var creditResult = response.CreditCardTransactionResultCollection[0];
                        sale = new Sale()
                        {
                            AmountInCents = creditResult.AmountInCents,
                            CreditCardBrand = creditResult.CreditCard.CreditCardBrand,
                            CreditCardNumber = creditResult.CreditCard.MaskedCreditCardNumber,
                            Date = DateTime.Now,
                            Email = checkoutOrder.Email,
                            HolderName = checkoutOrder.NameOnCreditCard,
                            Name = checkoutOrder.Name,
                            OrderKey = response.OrderResult.OrderKey
                        };
                    }
                }
            }
            return sale;
        }
    }
}
