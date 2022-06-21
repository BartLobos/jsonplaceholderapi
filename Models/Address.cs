using System;
using System.Text.Json.Serialization;
using jsonplaceholderapi.Models;

namespace jsonplaceholderapi
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } 
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public User User { get; set; }

        public int GeoId { get; set; }
        public Geo Geo { get; set; }
    }
}
