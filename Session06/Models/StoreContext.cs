using Microsoft.EntityFrameworkCore;
using Session06.Models.DomainModels.ProductAggregates;

namespace Session06.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure entity relationships and properties here
        //    modelBuilder.Entity<Product>()
        //        .HasOne(p => p.Category)
        //        .WithMany(c => c.Products)
        //        .HasForeignKey(p => p.CategoryId);
        //    modelBuilder.Entity<OrderItem>()
        //        .HasOne(oi => oi.Product)
        //        .WithMany(p => p.OrderItems)
        //        .HasForeignKey(oi => oi.ProductId);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
