using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mundipagg.Checkout.Application
{
    [DataContract]
    public class AuthenticationView
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "isAuthenticated")]
        public bool IsAuthenticated { get; set; }
        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
        }
    }
}
