using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DAL.DAL;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
{
    public class CustomerBll
    {
        CustomerDal _customer = new CustomerDal();
        public bool Add(Customer customer)
        {
            return _customer.Add(customer);
        }
    }
}
