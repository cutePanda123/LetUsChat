using LetUsChat.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LetUsChatTest
{
    public class AuthenticationControllerUnitTests
    {
        private Mock<ILogger<AuthenticationController>> mockedLogger = new Mock<ILogger<AuthenticationController>>();

        [Fact]
        public void SignIn_Pass_Test()
        {
            var controller = new AuthenticationController(mockedLogger.Object);

            var actionResult = controller.SignIn();

            Assert.NotNull(actionResult);
            Assert.IsType<ChallengeResult>(actionResult);
            Assert.Equal(1, ((ChallengeResult)actionResult).Properties.Items.Count);
        }
    }
}
