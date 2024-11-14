using Microsoft.EntityFrameworkCore;
using ClientSalesRegistry.Models;


namespace ClientSalesRegistry.Data
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<SaleItem>().ToTable("SaleItem");

        }
    }

}
