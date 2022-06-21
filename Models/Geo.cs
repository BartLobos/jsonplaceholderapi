using System;

namespace jsonplaceholderapi
{
    public class Geo
    {
        public int Id { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }
        public Address Address { get; set; }
    }
}
