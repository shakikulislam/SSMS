using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.Models;

namespace SSMS.DatabaseContext.DatabaseContext
{
    public class SSMSDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
