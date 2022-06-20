using System;

namespace jsonplaceholderapi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string body { get; set; }
    }
}
