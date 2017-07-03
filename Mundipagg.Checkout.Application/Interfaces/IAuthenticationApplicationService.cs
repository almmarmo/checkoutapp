using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Application
{
    public interface IAuthenticationApplicationService
    {
        AuthenticationView SignIn(AuthenticationView view);
    }
}
