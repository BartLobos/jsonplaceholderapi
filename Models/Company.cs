using System;
using jsonplaceholderapi.Models;

namespace jsonplaceholderapi
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPharse { get; set; }
        public string Bs { get; set; }
        public User User { get; set; }

    }
}
