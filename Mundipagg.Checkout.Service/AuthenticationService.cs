using Mundipagg.Checkout.Domain;

namespace Mundipagg.Checkout.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository authenticationRepository;
        IAuthenticationTokenRepository authenticationTokenRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, IAuthenticationTokenRepository authenticationTokenRepository)
        {
            this.authenticationRepository = authenticationRepository;
            this.authenticationTokenRepository = authenticationTokenRepository;
        }

        public AuthenticationToken SignIn(string username, string password)
        {
            var signin = authenticationRepository.SignIn(username, password);
            if(signin != null)
                authenticationTokenRepository.Save(signin);

            return signin;
        }
    }
}
