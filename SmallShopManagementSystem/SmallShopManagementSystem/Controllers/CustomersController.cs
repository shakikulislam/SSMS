using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSMS.BLL.BLL;
using SSMS.Models.Models;

namespace SmallShopManagementSystem.Controllers
{
    public class CustomersController : Controller
    {
        CustomerBll _customer = new CustomerBll();
        //
        // GET: /Customers/
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer, HttpPostedFileBase UploadImage)
        {
            try
            {
                

                if (UploadImage != null)
                {
                    customer.Image = new byte[UploadImage.ContentLength];
                    UploadImage.InputStream.Read(customer.Image, 0, UploadImage.ContentLength);
                }
                var added = _customer.Add(customer);
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
            ModelState.Clear();
            return View();
        }



        [HttpPost]
        public ActionResult Update(Customer customer)
        {
            try
            {
                var aCustomer = _customer.GetCustomerById(customer.Code);
                if (aCustomer != null)
                {

                    aCustomer.Name = customer.Name;
                    aCustomer.Code = customer.Code;
                    aCustomer.Address = customer.Address;
                    aCustomer.Email = customer.Email;
                    aCustomer.Contact = customer.Contact;
                    aCustomer.LoyalityPoint = customer.LoyalityPoint;

                    var isUpdate = _customer.Update(aCustomer);
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
                    ViewBag.FMsg = "Customer not found.";
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
            var aCustomer = _customer.GetCustomerById(code);
            return View(aCustomer);

        }

        //[HttpPost]
        public ActionResult Delete(string  Code)
        {
            try
            {
                var aCustomer = _customer.GetCustomerById(Code);
                if (aCustomer != null)
                {
                    var isDelete = _customer.Delete(aCustomer);
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
                    ViewBag.FMsg = "Customer not found.";
                }
            }
            catch (Exception exception)
            {
                ViewBag.FMsg = exception.Message;
            }
            return View();
        }

        //public ActionResult Delete()
        //{
        //    return View();
        //}

        public ActionResult Show()
        {
            var dataList = _customer.Show();
            return View(dataList);

        }
    }
}