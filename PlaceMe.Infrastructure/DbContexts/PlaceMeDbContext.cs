using Microsoft.EntityFrameworkCore;
using PlaceMe.Infrastructure.Entities;

namespace PlaceMe.Infrastructure.DbContexts
{
    public class PlaceMeDbContext : DbContext
    {
        public PlaceMeDbContext(DbContextOptions<PlaceMeDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionLine> PromotionLines { get; set; }
        public DbSet<ImageLine> ImageLines { get; set; }
        public DbSet<DescriptionLine> DescriptionLines { get; set; }
        public DbSet<AddressLine> AddressLines { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
