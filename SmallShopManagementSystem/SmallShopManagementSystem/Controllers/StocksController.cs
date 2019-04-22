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
    public class StocksController : Controller
    {
        SSMSDbContext _db=new SSMSDbContext();
        StockBll _stockBll=new StockBll();
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string name)
        {
            var dataList = from s in _db.Stocks
                           select s;
            if (!string.IsNullOrEmpty(name))
            {
                dataList = dataList.Where(c => c.product.Name.Contains(name));
            }
            return View(dataList.ToList());
            //var dataList = _stockBll.Search();
            //return View(dataList);
        }


	}
}