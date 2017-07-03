using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Application
{
    public interface ICheckoutApplicationService
    {
        SaleView OrderSale(CheckoutOrderView oder);
    }
}
