using System;
using jsonplaceholderapi.Models;
using Microsoft.EntityFrameworkCore;

namespace jsonplaceholderapi.Data
{
    public class JsonPlaceholderDbContext : DbContext
    {
        public JsonPlaceholderDbContext(DbContextOptions<JsonPlaceholderDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Company> Companies { get; set; }



    }
}
