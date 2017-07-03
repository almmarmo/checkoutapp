using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Domain
{
    public interface ISaleService
    {
        Sale OrderSale(CheckoutOrder checkoutOrder);
    }
}
