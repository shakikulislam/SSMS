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

        public Customer GetCustomerById(string code)
        {
            return _customer.GetCustomerById(code);
        }

        public bool Update(Customer customer)
        {
            return _customer.Update(customer);
        }

        public bool Delete(Customer customer)
        {
            bool deleted = _customer.Delete(customer);

            return deleted;
        }

       

        public List<Customer> Show()
        {
            var model = new List<Customer>();
            model = _customer.Show();
            return model;
        }
    }
}
