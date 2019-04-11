using System.Data.Entity;
using SSMS.Models.Models;

namespace SSMS.DatabaseContext.DatabaseContext
{
    public class SSMSDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customrs { get; set; }

    }
}