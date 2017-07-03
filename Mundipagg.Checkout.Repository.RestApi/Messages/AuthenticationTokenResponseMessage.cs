using System;
using System.Runtime.Serialization;

namespace Mundipagg.Checkout.Repository.RestApi.Messages
{
	[DataContract]
    public class AuthenticationTokenResponseMessage
    {
        [DataMember(Name="accessToken")]
        public string AccessToken { get; set; }
        [DataMember(Name = "tokenType")]
        public string TokenType { get; set; }
        [DataMember(Name = "expiresIn")]
        public int ExpiresIn { get; set; }
        [DataMember(Name = "userId")]
        public Guid UserId { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "refreshToken")]
        public string RefreshToken { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "customerKey")]
        public string CustomerKey { get; set; }

    }
}
