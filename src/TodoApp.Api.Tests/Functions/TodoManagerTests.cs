using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TodoApp.Api.Functions;

namespace TodoApp.Api.Tests.Functions
{
    public class TodoManagerTests
    {
        private TodoManager _todoManager;

        [SetUp]
        public void Setup()
        {
            _todoManager = new TodoManager();
        }

        [Test]
        public async Task Should_ReturnOkWithGenericMessage_When_NoPayload()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;

            var loggerMock = new Mock<ILogger>();

            // Act
            var response = (OkObjectResult) await _todoManager.Run(request, loggerMock.Object);

            // Assert
            Assert.AreEqual(response.Value, "Hello");
        }
    }
}