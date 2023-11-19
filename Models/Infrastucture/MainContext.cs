using Microsoft.EntityFrameworkCore;

namespace FoodMart.Models.Infrastucture
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
            
        }
    }
}
