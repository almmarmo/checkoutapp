using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mundipagg.Checkout.Application;
using Mundipagg.Checkout.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mundipagg.Checkout.WebApi.Controllers
{
	[Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        ICheckoutApplicationService checkoutApplicationService;
		public CheckoutController(ICheckoutApplicationService checkoutApplicationService)
		{
			this.checkoutApplicationService = checkoutApplicationService;
		}

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]CheckoutOrderView value)
        {
            SaleView saleView = null;
            try
            {
                saleView = checkoutApplicationService.OrderSale(value);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Json(saleView);
		}
    }
}
