using System;
using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Application
{
    public class AuthenticationApplicationService : IAuthenticationApplicationService
    {
        IAuthenticationService authenticationService;
        public AuthenticationApplicationService(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        public AuthenticationView SignIn(AuthenticationView view)
        {
            if (view == null || !view.IsValid())
                throw new ArgumentException("Please inform username and password.");

            if (view.IsValid())
            {
                var auth = authenticationService.SignIn(view.Username, view.Password);
                if (auth != null && !String.IsNullOrEmpty(auth.AccessToken))
                {
                    view.AccessToken = auth.AccessToken;
                    view.IsAuthenticated = true;
                }
                else
                    view.IsAuthenticated = false;
            }

            return view;
        }
    }
}
