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
    public class CategoryRepository
    {
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Category category)
        {
            //_db.Suppliers.AddOrUpdate(supplier);
            _db.Categories.Add(category);
            var isSaved = _db.SaveChanges();
            return isSaved > 0 ? true : false;
            //return false;
        }

        public Category GetCategoryById(int id)
        {
            Category nCategory = _db.Categories.FirstOrDefault(c => c.Id == id);
            return nCategory;
        }

        public bool Delete(Category category)
        {
            bool isDeleted = false;


            _db.Categories.Remove(category);
            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isDeleted = true;

            return isDeleted;

        }



        public bool Update(Category category)
        {
            bool isUpdated = false;

            _db.Entry(category).State = EntityState.Modified;

            int rowAfected = _db.SaveChanges();

            if (rowAfected > 0)
                isUpdated = true;

            return isUpdated;
        }
        public Category GetCategoryById(string code)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Code == code);
            return category;
        }
        public List<Category> Show()
        {
            return _db.Categories.ToList();
        }


        //public List<Category> Show(int index)
        //{
        //    return _db.Categories.ToList();
        //}

      
    }
}
