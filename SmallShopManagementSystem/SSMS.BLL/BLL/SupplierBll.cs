using System.Collections.Generic;
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
        public bool Update(Supplier supplier)
        {
            bool isUpdate = _supplier.Update(supplier);
            return isUpdate;
        }
        
        public Supplier GetSupplierById(string code)
        {
            return _supplier.GetSupplierById(code);
        }

        public bool Delete(Supplier supplier)
        {
            bool isDelete = _supplier.Delete(supplier);
            return isDelete;
        }

        public List<Supplier> Show(int index)
        {
            return _supplier.Show(index);

        }
    }
}
