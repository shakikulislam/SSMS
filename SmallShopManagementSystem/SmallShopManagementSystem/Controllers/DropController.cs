using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.BLL.BLL;
using SSMS.Models.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class DropController : Controller
    {
        CustomerBll _customer = new CustomerBll();
        //
        // GET: /Drop/
        public ActionResult Show()
        {
            //var dataList = _customer.Show();
            //return View(dataList);

            var customerList = _customer.Show();
            ViewBag.Products = customerList;
            return View();
           
        }

        public ActionResult Index()
        {
            return View();
        }
      


    }
}