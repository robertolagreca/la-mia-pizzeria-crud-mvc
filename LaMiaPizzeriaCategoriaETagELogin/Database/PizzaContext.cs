using LaMiaPizzeriaCategoriaETagELogin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaCategoriaETagELogin.Database
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzaDBCatTagLoginv1;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
