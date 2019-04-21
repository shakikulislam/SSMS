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


        public bool Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public Product GetProductById(string code)
        {
            return _productRepository.GetProductById(code);
        }

        public bool Delete(Product product)
        {
            bool isDelete = _productRepository.Delete(product);
            return isDelete;
        }

        public List<Product> Show(int index)
        {
            return _productRepository.Show(index);

        }
    }
}
