using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class SuppliersController : Controller
    {
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add(Supplier supplier)
        {
            return View();
        }
	}
}