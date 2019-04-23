using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models.Models
{
    public class SaleVM
    {
        public  Customer customer { get; set; }
        public Sale sale { get; set; }
    }
}
