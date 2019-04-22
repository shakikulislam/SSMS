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
         CategoryBll _category = new CategoryBll();

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
        [HttpGet]
        public ActionResult Update(string code)
        {
            var aCategory = _category.GetCategoryById(code);
            return View(aCategory);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {

            try
            {
                var aCategory = _category.GetCategoryById(category.Code);
                if (aCategory != null)
                {

                    aCategory.Code = category.Code;
                    aCategory.Name = category.Name;
                   

                    var isUpdate = _category.Update(aCategory);
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
                    ViewBag.FMsg = "Category not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View();
        }


        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        public ActionResult Delete(string code)
        {
            try
            {
                var aCategory = _category.GetCategoryById(code);
                if (aCategory != null)
                {
                    var isDelete = _category.Delete(aCategory);
                    if (isDelete)
                    {

                        ViewBag.SDeleted = "Delete Success.";
                        //return RedirectToAction("Show");
                    }
                    else
                    {
                        ViewBag.NSDelete = "Delete Failed.";
                    }
                }
                else
                {
                    ViewBag.FMsg = "Category not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View();
        }

        //private const int index = 1;


        //public ActionResult Show(Category category)
        //{
        //    List<Category> aCategory = _category.Show();
        //    return View(aCategory);

        //}

        public ActionResult Show()
        {
            var dataList = _category.Show();
            return View(dataList);

        }


        public PartialViewResult GetCategoriePv()
        {
            return PartialView("~/Views/Shared/Categori/_CategoriViewPv.cshtml");

        }


    }
}