using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestAspNetCore.Models;

namespace TestAspNetCore.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Categore> Categorecs { get; set; }
        public DbSet<Employee> Employee { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Important: let IdentityDbContext configure identity entity keys/mappings
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categore>().HasData(
                new Categore() { Id = 1, Name = "SelectCategore" },
                new Categore() { Id = 2, Name = "Mobel " },
                new Categore() { Id = 3, Name = "Laptop " },
                new Categore() { Id = 4, Name = "Computer " }
            );
        }
    }
}