using System;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Service
{
	public class SaleService : ISaleService
	{
		ISaleRepository saleRepository;
        ICheckoutRepository checkoutRepository;

        public SaleService(ISaleRepository saleRepository, ICheckoutRepository checkoutRepository)
		{
			this.saleRepository = saleRepository;
            this.checkoutRepository = checkoutRepository;
		}

		public Sale OrderSale(CheckoutOrder checkoutOrder)
		{
            var sale = checkoutRepository.Checkout(checkoutOrder);
            if(sale != null)
                saleRepository.Save(sale);

            return sale;
		}
	}
}
