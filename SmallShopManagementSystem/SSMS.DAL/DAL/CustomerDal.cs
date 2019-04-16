using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
   public class CustomerDal
    {
        
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Customer customer)
        {
            bool saved = false;
            _db.Customers.Add(customer);
            var isSaved = _db.SaveChanges();
            if (isSaved > 0)
            {
                saved = true;
            }
            else
            {
                saved = false;
            }

            return saved;
        }
        public bool Update(Customer customer)
        {
            _db.Entry(customer).State = EntityState.Modified;
            var isUpdate = _db.SaveChanges();
            return isUpdate > 0 ? true : false;
        }
        //internal Customer GetCustomerById(string code)
        //{
           
        //}

        public Customer GetCustomerById(string code)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Code == code);
            return customer;
        }

        public bool Delete(Customer customer)
        {

            _db.Customers.Remove(customer);
            var isDelete = _db.SaveChanges();
            return isDelete > 0 ? true : false;
        }

        public List<Customer> Show()
        {
            return _db.Customers.ToList();
        }

       
    }
    }

