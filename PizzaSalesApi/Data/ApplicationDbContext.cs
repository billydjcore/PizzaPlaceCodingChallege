using Microsoft.EntityFrameworkCore;
using PizzaPlaceApi.Data.Models;

namespace PizzaPlaceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderDetails> order_details { get; set; }

        public DbSet<Pizza> pizzas { get; set; }

        public DbSet<PizzaType> pizza_types { get; set; }
    }
}
