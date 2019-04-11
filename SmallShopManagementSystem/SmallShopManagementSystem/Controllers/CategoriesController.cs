using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.BLL.BLL;
using SSMS.Models.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryBll _category = new CategoryBll();

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            try
            {
                var added = _category.Add(category);
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