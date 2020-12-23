using System;
using Newtonsoft.Json;

namespace TodoApp.Api.Models
{
    public class TodoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("due")]
        public DateTime Due { get; set; }
    }
}