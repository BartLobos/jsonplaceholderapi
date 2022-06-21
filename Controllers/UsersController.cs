using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jsonplaceholderapi.Data;
using jsonplaceholderapi.Models;

namespace jsonplaceholderapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JsonPlaceholderDbContext _context;

        public UsersController(JsonPlaceholderDbContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetUsers(int? id)
        {
            if (id != null)
            {
                var user = await _context.Users
                    .Select(x => new User()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Username = x.Username,
                        Email = x.Email,
                        Website = x.Website,
                        Phone = x.Phone,
                        Address = x.Address,
                        Company = x.Company
                    }).FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    return NotFound(new { Message = "User not found" });
                return Ok(user);
            }
            var users = await _context.Users
                .Select(x => new UserView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    Email = x.Email,
                    Website = x.Website,
                    Phone = x.Phone,
                    Address = (new AddressView()
                        {
                            Street = x.Address.Street,
                            Suite = x.Address.Suite,
                            City = x.Address.City,
                            Zipcode = x.Address.Zipcode,
                            Geo = x.Address.Geo
                        }),
                    Company = x.Company,
                }).ToListAsync();
            if (users == null)
                return NotFound(new { Message = "No users" });
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsers(List<User> users)
        {
            //users.ForEach(x => {x.CompanyId = x.Company.Id; x.AddressId = x.Address.Id; x.Address.GeoId = x.Address.Geo.Id;});
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            return Created("", users);
        }
    }
}
