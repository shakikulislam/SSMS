using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models;

namespace SSMS.DAL
{
    public class SupplierDal
    {
        private SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Supplier supplier)
        {
            _db.Suppliers.Add(supplier);
            var isSaved = _db.SaveChanges();
            return isSaved > 0 ? true : false;
        }
    }
}
