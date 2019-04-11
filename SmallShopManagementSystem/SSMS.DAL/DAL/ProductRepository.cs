using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class ProductRepository
    {
        SSMSDbContext _db = new SSMSDbContext();


        public bool Add(Product product)
        {
            bool isSaved = false;

            _db.Products.Add(product);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isSaved = true;

            return isSaved;

        }
    }
}
