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


                _db.Sales.Add(sale);
                var isAdded = _db.SaveChanges() > 0;
                if (isAdded)
                {
                    return View(sale);
                }
            }
            return View();

        }

        public ActionResult Create()
        {
            var model = new Customer();
            model.CustomerLookUp = GetCustomerSelectListItems();
            //model.SubDistrictLookUp = GetDefaultSelectListItem();
            return View(model);
        }


        //public ActionResult Detail(long id)
        //{
        //    var purchase = _db.Purchases.Find(id);
        //    return View(purchase);
        //}

        public List<SelectListItem> GetCustomerSelectListItems()
        {
            var dataList = _db.Customers.ToList();

            var customerSelectListItems = new List<SelectListItem>();

            customerSelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var subDistrict in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = subDistrict.Name;
                    selectListItem.Value = subDistrict.Id.ToString();

                    customerSelectListItems.Add(selectListItem);
                }
            }
            return customerSelectListItems;
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