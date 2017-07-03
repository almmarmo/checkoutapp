namespace Mundipagg.Checkout.Domain
{
	public interface IAuthenticationRepository
    {
        AuthenticationToken SignIn(string username, string password);
    }
}
