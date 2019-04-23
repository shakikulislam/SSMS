using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.Models.Models;

namespace SSMS.DatabaseContext.DatabaseContext
{
    public class SSMSDbContext: DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

<<<<<<< HEAD
        public DbSet<Purchase> Purchases { get; set; }
=======
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetails> SaleDetails { get; set; }

>>>>>>> 09a3301de4e64208b5fec0e2b2bb41ba6d79129b

        //public DbSet<PurchaseDetails> Purchase { get; set; } 
    }
}
