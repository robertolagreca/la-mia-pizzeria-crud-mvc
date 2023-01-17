using LaMiaPizzeriaModel.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaModel.Database
{
    public class PizzaContext : DbContext
    {

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzaDBv1;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
