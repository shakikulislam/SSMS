using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DAL.DAL;
using SSMS.Models.Models;

namespace SSMS.BLL.BLL
{
    public class ProductBll
    {
       ProductRepository _productRepository = new ProductRepository();
        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }
    }
}
