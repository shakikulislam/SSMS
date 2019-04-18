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
    public class ProductsController : Controller
    {
        SSMSDbContext _db = new SSMSDbContext();
        private ProductBll _productBll = new ProductBll();

        public ActionResult Add()
        {
            var model = new Product();
            model.CategoryLookUp = GetCategorySelectListItems();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            var model = new Product();
            model.CategoryLookUp = GetCategorySelectListItems();
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
            return View(model);

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
        public List<SelectListItem> GetCategorySelectListItems()
        {
            var dataList = _db.Categories.ToList();

            var categorySelectListItems = new List<SelectListItem>();

            categorySelectListItems.AddRange(GetDefaultSelectListItem());

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var category in dataList)
                {
                    var selectListItem = new SelectListItem();
                    selectListItem.Text = category.Name;
                    selectListItem.Value = category.Id.ToString();

                    categorySelectListItems.Add(selectListItem);
                }
            }
            return categorySelectListItems;
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