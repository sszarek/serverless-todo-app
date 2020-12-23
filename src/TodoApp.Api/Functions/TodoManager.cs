using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TodoApp.Api.Models;

namespace TodoApp.Api.Functions
{
    public class TodoManager
    {
        [FunctionName(nameof(GetAllTodosV1))]
        public IActionResult GetAllTodosV1(
            [HttpTrigger(AuthorizationLevel.Function, HttpConstants.Get, Route = "v1/todo")] HttpRequest req,
            [CosmosDB(
                DatabaseConstants.DbName,
                DatabaseConstants.CollectionName,
                ConnectionStringSetting = DatabaseConstants.ConnectionStringSetting,
                SqlQuery = "SELECT * FROM c"
            )] IEnumerable<TodoItem> todoItems,
            ILogger log)
        {
            return new OkObjectResult(todoItems);
        }

        [FunctionName(nameof(GetTodoItemByIdV1))]
        public IActionResult GetTodoItemByIdV1(
            [HttpTrigger(AuthorizationLevel.Function, HttpConstants.Get, Route = "v1/todo/{id}")] HttpRequest req,
            [CosmosDB(
                DatabaseConstants.DbName,
                DatabaseConstants.CollectionName,
                ConnectionStringSetting = DatabaseConstants.ConnectionStringSetting,
                PartitionKey = "{id}",
                Id = "{id}"
                )] TodoItem todoItem
            )
        {
            return todoItem switch
            {
                null => new NotFoundResult(),
                _ => new OkObjectResult(todoItem)
            };
        }

        [FunctionName(nameof(CreateTodoV1))]
        public IActionResult CreateTodoV1(
            [HttpTrigger(AuthorizationLevel.Function, HttpConstants.Post, Route = "v1/todo")] TodoItem todoItem,
            [CosmosDB(
                DatabaseConstants.DbName,
                DatabaseConstants.CollectionName,
                ConnectionStringSetting = DatabaseConstants.ConnectionStringSetting
            )] out TodoItem document
        )
        {
            document = todoItem;
            document.Id = Guid.NewGuid().ToString();
            
            return new CreatedResult($"v1/todo/{todoItem.Id}", document);
        }
    }
}
