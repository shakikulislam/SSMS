using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.Models;
using SSMS.BLL;
using SSMS.BLL.BLL;
using SSMS.Models.Models;

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
        public ActionResult Add(Supplier supplier, HttpPostedFileBase UploadImage)
        {
            try
            {
                if (UploadImage != null)
                {
                    supplier.Image = new byte[UploadImage.ContentLength];
                    UploadImage.InputStream.Read(supplier.Image, 0, UploadImage.ContentLength);
                }
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


        public ActionResult Update(string code)
        {
            var aSupplier = _supplier.GetSupplierById(code);
            return View(aSupplier);
        }
        [HttpPost]
        public ActionResult Update(Supplier supplier)
        {

            try
            {
                var aSupplier = _supplier.GetSupplierById(supplier.Code);
                if (aSupplier != null)
                {

                    aSupplier.Code = supplier.Code;
                    aSupplier.Name = supplier.Name;
                    aSupplier.Address = supplier.Address;
                    aSupplier.Email = supplier.Email;
                    aSupplier.Contact = supplier.Contact;
                    aSupplier.ContactPerson = supplier.ContactPerson;

                    var isUpdate = _supplier.Update(aSupplier);
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
                    ViewBag.FMsg = "Supplier not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View();
        }


      
        public ActionResult Delete(string code)
        {
            try
            {
                var aSupplier = _supplier.GetSupplierById(code);
                if (aSupplier != null)
                {
                    var isDelete = _supplier.Delete(aSupplier);
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
                    ViewBag.FMsg = "Supplier not found.";
                }
            }
            catch (Exception exception)
            {

                ViewBag.FMsg = exception.Message;
            }
            return View();
        }

        private const int index = 1;


        public ActionResult Show(Supplier supplier)
        {
            List<Supplier> aSupplier = _supplier.Show(index);
            return View(aSupplier);

        }
	}
}