using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mundipagg.Checkout.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mundipagg.Checkout.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        IAuthenticationApplicationService authenticationApplicationService;
        public AuthenticationController(IAuthenticationApplicationService authenticationApplicationService)
        {
            this.authenticationApplicationService = authenticationApplicationService;
        }
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AuthenticationView value)
        {
            AuthenticationView view = null;
            try
            {
                view = authenticationApplicationService.SignIn(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(view);
        }
    }
}
