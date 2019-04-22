using System.Data.Entity;
using SSMS.Models.Models;

namespace SSMS.DatabaseContext.DatabaseContext
{
    public class SSMSDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetailses { get; set; } 
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }

        public DbSet<SaleVM> SaleVms { get; set; }
        public DbSet<Stock> Stocks { get; set; }


    }
}