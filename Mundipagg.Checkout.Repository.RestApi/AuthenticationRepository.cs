using Mundipagg.Checkout.Domain;
using Mundipagg.Checkout.Repository.RestApi.Messages;

namespace Mundipagg.Checkout.Repository.RestApi
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        public AuthenticationToken SignIn(string username, string password)
        {
            using (MundipaggApiClient client = new MundipaggApiClient())
            {
				var response = client.Authenticate<AuthenticationTokenResponseMessage>(username, password);

                return new AuthenticationToken()
                {
                    AccessToken = response.AccessToken,
                    CustomerKey = response.CustomerKey,
                    Name = response.Name,
                    RefreshToken = response.RefreshToken,
                    TokenType = response.TokenType,
                    UserId = response.UserId,
                    Username = response.Username
                };
            }
        }
    }
}
