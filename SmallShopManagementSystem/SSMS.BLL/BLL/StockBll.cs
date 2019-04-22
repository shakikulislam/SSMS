using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DAL.DAL;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
{
    public class StockBll
    {
        StockDal _stockDal=new StockDal();
        //public List<Stock> Show()
        //{
        //    var model = new List<Stock>();
        //    model = _stock.Show();
        //    return model;
        //}
        public List<Stock> Search()
        {
            var dataList = _stockDal.Search();
            return dataList;
        }
    }
}
