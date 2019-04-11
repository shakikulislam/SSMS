using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
    public class ProductRepository
    {
        SSMSDbContext _db = new SSMSDbContext();


        public bool Add(Product product)
        {
            bool isSaved = false;

            _db.Products.Add(product);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isSaved = true;

            return isSaved;

        }
        public Product GetCustomerById(int id)
        {
            Product nProduct = _db.Products.Where(c => c.Id == id).FirstOrDefault();
            return nProduct;
        }

        public bool Delete(Product product)
        {
            bool isDeleted = false;


            _db.Products.Remove(product);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isDeleted = true;

            return isDeleted;
        }



        public bool Update(Product product)
        {
            bool isUpdated = false;

            _db.Entry(product).State = EntityState.Modified;

            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isUpdated = true;

            return isUpdated;
        }
        public Product GetProductById(string code)
        {
            var product = _db.Products.FirstOrDefault(c => c.Code == code);
            return product;
        }


        public List<Product> Show(int index)
        {
            return _db.Products.ToList();
        }
    }
}
