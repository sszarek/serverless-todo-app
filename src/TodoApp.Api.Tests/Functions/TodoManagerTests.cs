using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TodoApp.Api.Functions;
using TodoApp.Api.Models;

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
        public void GetAllTodosV1_DataAvailable_OkWithTodoItemsReturned()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;

            var todoItems = new[]
            {
                new TodoItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Buy milk",
                    Description = "Lactose free",
                }
            };

            var loggerMock = new Mock<ILogger>();

            // Act
            var response = (OkObjectResult) _todoManager.GetAllTodosV1(request, todoItems, loggerMock.Object);

            // Assert
            Assert.AreEqual(response.Value, todoItems);
        }

        [Test]
        public void GetTodoItemByIdV1_TodoItemNotFound_NotFoundStatusReturned()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;

            // Act
            var response = (StatusCodeResult) _todoManager.GetTodoItemByIdV1(request, null);

            // Assert
            Assert.AreEqual(response.StatusCode, StatusCodes.Status404NotFound);
        }

        [Test]
        public void GetTodoItemByIdV1_TodoItemFound_OkStatusWithObjectReturned()
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var request = httpContext.Request;

            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Buy milk",
                Description = "Lactose free",
            };

            // Act
            var response = (OkObjectResult) _todoManager.GetTodoItemByIdV1(request, todoItem);

            // Assert
            Assert.AreEqual(response.Value, todoItem);
        }
    }
}