using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class StockDal
    {
        SSMSDbContext _db=new SSMSDbContext();
        //public Sale GetDetailsById(string name)
        //{
        //    var details = _db.Sales.FirstOrDefault(c => c.CustomerName == name);
        //    return details;
        //}

        //public List<Customer> Show()
        //{
        //    return _db.Customers.ToList();
        //}
        public List<Stock> Search()
        {
            return _db.Stocks.ToList();
        }
    }
}
