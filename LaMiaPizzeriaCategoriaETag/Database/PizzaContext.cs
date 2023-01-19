using LaMiaPizzeriaCategoriaETag.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaCategoriaETag.Database
{
    public class PizzaContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzaDBCatTagv1;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
