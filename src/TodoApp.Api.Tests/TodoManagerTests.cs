using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace TodoApp.Api.Tests
{
    public class TodoManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Should_ReturnOkWithGenericMessage_When_NoPayload()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;

            var loggerMock = new Mock<ILogger>();

            // Act
            var response = (OkObjectResult) await TodoManager.Run(request, loggerMock.Object);

            // Assert
            Assert.AreEqual(response.Value, "Hello");
        }
    }
}