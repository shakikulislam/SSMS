using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class CategoryRepository
    {
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Category category)
        {
            //_db.Suppliers.AddOrUpdate(supplier);
            _db.Categories.Add(category);
            var isSaved = _db.SaveChanges();
            return isSaved > 0 ? true : false;
            //return false;
        }
    }
}
