
using LaMiaPizzeriaModelConOrdini.Models;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeriaModelConOrdini.Database
{
    public class PizzaContext : DbContext
	{

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=PizzaDBConOrdini;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}
