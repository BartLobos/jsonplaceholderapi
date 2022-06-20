using System;

namespace jsonplaceholderapi.Models
{
    public class Todo
    {
        public int id { get; set; } 
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
