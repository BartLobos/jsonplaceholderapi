using System;
using System.Text.Json.Serialization;
using jsonplaceholderapi.Models;

namespace jsonplaceholderapi
{
    public class AddressView
    {
        public string Street { get; set; } 
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }
}
