using System;
using System.Collections.Generic;
using System.Text;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Application.Mappers
{
    public class SaleMapper
    {
        public static CheckoutOrder MapToDomain(CheckoutOrderView order)
        {
            CheckoutOrder checkout = null;

            if (order != null)
            {
                checkout = new CheckoutOrder()
                {
                    CreditCardFlag = order.CreditCardFlag,
                    CreditCardNumber = order.CreditCardNumber,
                    Email = order.Email,
                    ExpirationMonth = order.ExpirationMonth,
                    ExpirationYear = order.ExpirationYear,
                    Name = order.Name,
                    NameOnCreditCard = order.NameOnCreditCard,
                    SecurityCode = order.SecurityCode,
                    TransactionValue = order.TransactionValue,
                    MerchantId = order.MerchantId
                };
            }

            return checkout;
        }

        public static SaleView MapToView(Sale sale)
        {
            SaleView saleView = null;

            if (sale != null)
            {
                saleView = new SaleView()
                {
                    AmountInCents = sale.AmountInCents,
                    CreditCardBrand = sale.CreditCardBrand,
                    CreditCardNumber = sale.CreditCardNumber,
                    Date = sale.Date,
                    Email = sale.Email,
                    HolderName = sale.HolderName,
                    Name = sale.Name,
                    OrderKey = sale.OrderKey
                };
            }

            return saleView;
        }
    }
}
