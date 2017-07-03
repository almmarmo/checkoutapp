using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Mundipagg.Checkout.Application;
using Mundipagg.Checkout.WebApi.Controllers;
using Xunit;

namespace Mundipagg.Checkout.UnitTest
{
    public class AuthenticationControllerTest
    {
        [Fact]
        public void PostTest_Success()
        {
            var view = new AuthenticationView()
            {
                Username = "teste",
                Password = "123"
            };
            Mock<IAuthenticationApplicationService> appServiceMock = new Mock<IAuthenticationApplicationService>();
            appServiceMock.Setup(x => x.SignIn(It.IsAny<AuthenticationView>()))
                .Returns(new AuthenticationView());
            AuthenticationController controller = new AuthenticationController(appServiceMock.Object);
            var result = controller.Post(view);


            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void PostTest_Fail()
        {
            var view = new AuthenticationView()
            {
                Username = "",
                Password = ""
            };
            Mock<IAuthenticationApplicationService> appServiceMock = new Mock<IAuthenticationApplicationService>();
            appServiceMock.Setup(x => x.SignIn(It.IsAny<AuthenticationView>()))
                .Throws(new ArgumentException());
            AuthenticationController controller = new AuthenticationController(appServiceMock.Object);
            var result = controller.Post(view);

            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
