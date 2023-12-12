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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, ImageLink = "https://klike.net/uploads/posts/2022-09/1662040170_j-50.jpg", Name = "Яблоко", Cost = 100},
                new Product() { Id = 2, ImageLink = "https://media.baamboozle.com/uploads/images/119504/1666966541_1034289_gif-url.jpeg", Name = "Банан", Cost = 150 },
                new Product() { Id = 3, ImageLink = "https://cojo.ru/wp-content/uploads/2023/01/granat-bez-kostochek-1.webp", Name = "Гранат", Cost = 500 },
                new Product() { Id = 4, ImageLink = "https://ketokotleta.ru/wp-content/uploads/3/d/8/3d82223993fa9b0adf0be050b0e682e7.png", Name = "Груша", Cost = 400 },
                new Product() { Id = 5, ImageLink = "https://catherineasquithgallery.com/uploads/posts/2021-03/1614548312_46-p-apelsin-na-belom-fone-61.jpg", Name = "Апельсин", Cost = 300 }
                ) ;
        }
    }
}
