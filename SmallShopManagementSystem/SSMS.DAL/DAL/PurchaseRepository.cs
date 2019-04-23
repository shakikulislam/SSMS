using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class PurchaseRepository
    {
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Purchase purchase)
        {
            bool isSaved = false;

            _db.Purchases.Add(purchase);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isSaved = true;

            return isSaved;

        }
        //public Purchase GetCustomerById(int id)
        //{
        //    Purchase nProduct = _db.Purchases.Where(c => c.Id == id).FirstOrDefault();
        //    return nProduct;
        //}

        public bool Delete(Purchase purchase)
        {
            bool isDeleted = false;


            _db.Purchases.Remove(purchase);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isDeleted = true;

            return isDeleted;
        }



        public bool Update(Purchase purchase)
        {
            bool isUpdated = false;

            _db.Entry(purchase).State = EntityState.Modified;

            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isUpdated = true;

            return isUpdated;
        }
        public Purchase GetPurchaseById(int id)
        {
            var purchase = _db.Purchases.FirstOrDefault(c => c.Id == id);
            return purchase;
        }


        public List<Purchase> Show()
        {
            return _db.Purchases.ToList();
        }
    }
}
