using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.Models;
using SSMS.DAL;

namespace SSMS.BLL
{
    public class SupplierBll
    {
        SupplierDal _supplier=new SupplierDal();
        public bool Add(Supplier supplier)
        {
            return _supplier.Add(supplier);
        }
    }
}
