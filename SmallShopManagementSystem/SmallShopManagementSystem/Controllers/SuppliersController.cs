using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.Models;
using SSMS.BLL;

namespace SmallShopManagementSystem.Controllers
{
    public class SuppliersController : Controller
    {
        SupplierBll _supplier=new SupplierBll();
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            try
            {
            var added = _supplier.Add(supplier);
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
            return View();
        }
	}
}