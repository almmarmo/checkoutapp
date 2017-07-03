using System;

namespace Mundipagg.Checkout.Domain
{
	public class AuthenticationToken
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public string CustomerKey { get; set; }
    }
}
