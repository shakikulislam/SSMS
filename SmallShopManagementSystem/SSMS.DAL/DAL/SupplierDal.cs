using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public Supplier GetSupplierById(int id)
        {
            Supplier nSupplier = _db.Suppliers.Where(c => c.Id == id).FirstOrDefault();
            return nSupplier;
        }

        public bool Delete(Supplier supplier)
        {
            bool isDeleted = false;


            _db.Suppliers.Remove(supplier);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isDeleted = true;

            return isDeleted;
        }



        public bool Update(Supplier supplier)
        {
            bool isUpdated = false;

            _db.Entry(supplier).State = EntityState.Modified;

            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isUpdated = true;

            return isUpdated;
        }
        public Supplier GetSupplierById(string code)
        {
            var supplier = _db.Suppliers.FirstOrDefault(c => c.Code == code);
            return supplier;
        }


        public List<Supplier> Show(int index)
        {
            return _db.Suppliers.ToList();
        }

        
    }
}
