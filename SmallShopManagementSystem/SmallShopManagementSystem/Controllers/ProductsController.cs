using System;
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

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {

            try
            {
                var aProduct = _productBll.GetProductById(product.Code);
                if (aProduct != null)
                {

                    aProduct.Code = product.Code;
                    aProduct.Name = product.Name;
                    aProduct.Category = product.Category;
                    aProduct.ReorderLevel = product.ReorderLevel;
                    aProduct.Description = product.Description;

                    var isUpdate = _productBll.Update(aProduct);
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
                    ViewBag.FMsg = "Product not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                var aProduct = _productBll.GetProductById(product.Code);
                if (aProduct != null)
                {
                    var isDelete = _productBll.Delete(aProduct);
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
                    ViewBag.FMsg = "Product not found.";
                }
            }
            catch (Exception exception)
            {

                ViewBag.FMsg = exception.Message;
            }
            return View();
        }

        private const int index = 1;


        public ActionResult Show(Product product)
        {
            List<Product> aProduct = _productBll.Show(index);
            return View(aProduct);

        }



	}
}