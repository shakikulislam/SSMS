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
    public class PurchasesController : Controller
    {
        SSMSDbContext _db = new SSMSDbContext();
        private PurchaseBll _purchaseBll = new PurchaseBll();

        public ActionResult Add()
        {
            var model = new Purchase();
            model.SupplierLookUp = GetSupplierSelectListItems();
            model.ProductLookUp = GetProductSelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Purchase purchase)
        {
            //var model = new Purchase();
           
            //model.SupplierLookUp = GetSupplierSelectListItems();
            //model.ProductLookUp = GetProductSelectListItems();
            try
            {
                var added = _purchaseBll.Add(purchase);
                if (added)
                {
                    ViewBag.SMsg = "Save Success.";
                }
                else
                {
                    ViewBag.FMsg = "Failed";
                }

            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            //return View(model);
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Purchase purchase)
        {
            var model = new Purchase();
            try
            {
                var aPurchase = _purchaseBll.GetPurchaseById(purchase.Id);
                if (aPurchase != null)
                {

                    aPurchase.Date = purchase.Date;
                    aPurchase.Bill = purchase.Bill;
                    aPurchase.Supplier = purchase.Supplier;
                    aPurchase.Product = purchase.Product;
                    aPurchase.ManufacturedDate = purchase.ManufacturedDate;
                    aPurchase.ExpireDate = purchase.ExpireDate;
                    aPurchase.Quantity = purchase.Quantity;
                    aPurchase.UnitPrice = purchase.UnitPrice;
                    aPurchase.NewCostPrice = purchase.NewCostPrice;
                    aPurchase.NewMrp = purchase.NewMrp;

                    var isUpdate = _purchaseBll.Update(aPurchase);
                    if (isUpdate)
                    {
                        ViewBag.SUpdate = "Update Success.";
                    }
                    else
                    {
                        ViewBag.FUpdate = "Update Failed.";
                    }
                }
                else
                {
                    ViewBag.FMsg = "Purchase not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Purchase purchase)
        {
            try
            {
                var aPurchase = _purchaseBll.GetPurchaseById(purchase.Id);
                if (aPurchase != null)
                {
                    var isDelete = _purchaseBll.Delete(aPurchase);
                    if (isDelete)
                    {
                        ViewBag.SDeleted = "Delete Success.";
                    }
                    else
                    {
                        ViewBag.NSDelete = "Delete Failed.";
                    }
                }
                else
                {
                    ViewBag.FMsg = "Purchase not found.";
                }
            }
            catch (Exception exception)
            {

                ViewBag.FMsg = exception.Message;
            }
            return View();
        }

        private const int index = 1;

        public ActionResult Show(Purchase purchase)
        {
            List<Purchase> aPurchase = _purchaseBll.Show(index);
            return View(aPurchase);

        }
        public List<SelectListItem> GetSupplierSelectListItems()
        {
            var dataList = _db.Suppliers.ToList();

            var supplierSelectListItems = new List<SelectListItem>();

            supplierSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var supplier in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = supplier.Name;
                    selectListItem.Value = supplier.Id.ToString();

                    supplierSelectListItems.Add(selectListItem);
                }
            }
            return supplierSelectListItems;
        }

        public List<SelectListItem> GetProductSelectListItems()
        {
            var dataList = _db.Products.ToList();

            var productSelectListItems = new List<SelectListItem>();

            productSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var product in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = product.Name;
                    selectListItem.Value = product.Id.ToString();

                    productSelectListItems.Add(selectListItem);
                }
            }
            return productSelectListItems;
        }

        public List<SelectListItem> GetDefaultSelectListItem()
        {
            var dataList = new List<SelectListItem>();
            var defaultSelectListItem = new SelectListItem();
            defaultSelectListItem.Text = "---Select---";
            defaultSelectListItem.Value = "";
            dataList.Add(defaultSelectListItem);
            return dataList;
        }


	}
}