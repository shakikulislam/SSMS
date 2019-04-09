using SSMS.DAL.DAL;
using SSMS.Models;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
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
