using Microsoft.EntityFrameworkCore;
using PizzaPlace.Core.Entities;

namespace PizzaPlace.Infrastructure.DBContext
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
