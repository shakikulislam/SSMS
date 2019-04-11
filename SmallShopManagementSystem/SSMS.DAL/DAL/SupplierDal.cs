using System.Data.Entity;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class SupplierDal
    {
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Supplier supplier)
        {
            //_db.Suppliers.AddOrUpdate(supplier);
            _db.Suppliers.Add(supplier);
            var isSaved = _db.SaveChanges();
            return isSaved > 0 ? true : false;
            //return false;
        }

        
    }
}
