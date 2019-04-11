using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DAL.DAL;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
{
    public class CategoryBll
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
    }
}
