namespace Mundipagg.Checkout.Domain
{
	public interface IAuthenticationService
    {
        AuthenticationToken SignIn(string username, string password);
    }
}
