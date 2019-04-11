﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.BLL.BLL;
using SSMS.Models.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private ProductBll _productBll = new ProductBll();

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            try
            {
                var added = _productBll.Add(product);
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