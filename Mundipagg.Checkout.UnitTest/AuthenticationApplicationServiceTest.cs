using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Mundipagg.Checkout.Application;
using Mundipagg.Checkout.Domain;
using Xunit;

namespace Mundipagg.Checkout.UnitTest
{
    public class AuthenticationApplicationServiceTest
    {
        [Fact]
        public void Singin_Success()
        {
            Mock<IAuthenticationService> authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock.Setup(x => x.SignIn(It.IsAny<String>(), It.IsAny<String>()))
                .Returns(new AuthenticationToken()
                {
                    AccessToken = "wVN1EwuzSnTgRAiLxx24kg2uH132uSxMWiEq-sZNlf20Lh5ir5l_kBzY5cdjpuRp9jMnEgWXxcxoPXcwGI0OnoNpuGMrX1fBAr9qfWyXrUzXKrumwcU4Bn5emSc22f2L5lgpfArwCbla15MJAII9QrgdXh7wqp6fzPNOZvaSJpI0shSv2HJU5dDGT6QtIekuQXWCP-bMs7V0wi8OWeVMoUO25wzwIP0wYYsCTteSxvQ"
                });

            AuthenticationApplicationService appService = new AuthenticationApplicationService(authServiceMock.Object);

            var result = appService.SignIn(new AuthenticationView()
            {
                Username = "teste",
                Password = "123"
            });

            Assert.NotNull(result);
            Assert.True(result.IsAuthenticated);
        }

        [Fact]
        public void Singin_NotAuthenticated()
        {
            Mock<IAuthenticationService> authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock.Setup(x => x.SignIn(It.IsAny<String>(), It.IsAny<String>()))
                .Returns(new AuthenticationToken()
                {
                    AccessToken = null
                });

            AuthenticationApplicationService appService = new AuthenticationApplicationService(authServiceMock.Object);

            var result = appService.SignIn(new AuthenticationView()
            {
                Username = "teste",
                Password = "123"
            });

            Assert.NotNull(result);
            Assert.False(result.IsAuthenticated);
        }

        [Fact]
        public void Signin_Fail_UserAndPassword_Empty()
        {
            Mock<IAuthenticationService> authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock.Setup(x => x.SignIn(It.IsAny<String>(), It.IsAny<String>()))
                .Returns(new AuthenticationToken()
                {
                    AccessToken = "wVN1EwuzSnTgRAiLxx24kg2uH132uSxMWiEq-sZNlf20Lh5ir5l_kBzY5cdjpuRp9jMnEgWXxcxoPXcwGI0OnoNpuGMrX1fBAr9qfWyXrUzXKrumwcU4Bn5emSc22f2L5lgpfArwCbla15MJAII9QrgdXh7wqp6fzPNOZvaSJpI0shSv2HJU5dDGT6QtIekuQXWCP-bMs7V0wi8OWeVMoUO25wzwIP0wYYsCTteSxvQ"
                });

            AuthenticationApplicationService appService = new AuthenticationApplicationService(authServiceMock.Object);

            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var result = appService.SignIn(new AuthenticationView()
                {
                    Username = "",
                    Password = ""
                });
            });

            Assert.Equal("Please inform username and password.", ex.Message);

        }
    }
}
