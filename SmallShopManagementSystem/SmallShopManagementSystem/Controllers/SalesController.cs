using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.BLL.BLL;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        CustomerBll _customer = new CustomerBll();

        SSMSDbContext _db = new SSMSDbContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {

            if (ModelState.IsValid && sale.PurchaseDetailses != null && sale.PurchaseDetailses.Count > 0)
            {
                var customerList = _customer.Show();
                ViewBag.Products = customerList;
                //if (purchase.UploadFiles != null && purchase.UploadFiles[0] != null)
                //{


                //}


                _db.Sales.Add(sale);
                var isAdded = _db.SaveChanges() > 0;
                if (isAdded)
                {
                    //var inPurchase = _db.Purchases.Where(c => c.Id == purchase.Id).FirstOrDefault();
                    //purchase.PurchaseDetailses = inPurchase.PurchaseDetailses;
                    return View(sale);
                }
            }
            return View();

        }

        public ActionResult Create()
        {
            var customerList = _customer.Show();
            ViewBag.Products = customerList;
            return View();
        }


        //public ActionResult Detail(long id)
        //{
        //    var purchase = _db.Purchases.Find(id);
        //    return View(purchase);
        //}

    }
}