using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public Product product { get; set; }
    }
}
