using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DAL.DAL;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
{
    public class PurchaseBll
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }


        public bool Update(Purchase purchase)
        {
            bool isUpdate = _purchaseRepository.Update(purchase);
            return isUpdate;
        }
        public Purchase GetPurchaseById(int id)
        {
            return _purchaseRepository.GetPurchaseById(id);
        }

        public bool Delete(Purchase purchase)
        {
            bool isDelete = _purchaseRepository.Delete(purchase);
            return isDelete;
        }

        public List<Purchase> Show()
        {
            return _purchaseRepository.Show();

        }
    }
}
