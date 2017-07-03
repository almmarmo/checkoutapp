using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Domain
{
    public interface ISaleRepository
    {
		Sale Save(Sale checkoutOrder);
    }
}
