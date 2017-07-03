using System;
using Mundipagg.Checkout.Application.Mappers;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Application
{
    public class CheckoutApplicationService : ICheckoutApplicationService
    {
        ISaleService saleService;
        public CheckoutApplicationService(ISaleService saleService)
        {
            this.saleService = saleService;
        }
        public SaleView OrderSale(CheckoutOrderView order)
        {
            if (order == null)
                throw new ArgumentNullException("order", "Please inform checkout informations.");
            if (String.IsNullOrEmpty(order.MerchantId))
                throw new ArgumentNullException("MerchantId.");

            var checkout = SaleMapper.MapToDomain(order);
            var sale = saleService.OrderSale(checkout);

            SaleView saleView = SaleMapper.MapToView(sale);

            return saleView;
        }
    }
}
