using System;
using System.ComponentModel.DataAnnotations;

namespace jsonplaceholderapi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
