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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Address)
            //     .WithOne(a => a.User)
            //     .HasForeignKey<Address>(a => a.Id);
            // modelBuilder.Entity<Address>().ToTable("Users");
            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.Company)
            //     .WithOne(c => c.User)
            //     .HasForeignKey<Company>(c => c.Id);

            //  modelBuilder.Entity<Address>()
            //     .HasOne(a => a.Geo)
            //     .WithOne(g => g.Address)
            //     .HasForeignKey<Geo>(g => g.Id);
        }

    }
}
