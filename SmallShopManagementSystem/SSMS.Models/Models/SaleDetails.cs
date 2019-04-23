using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models.Models
{
    public class SaleDetails
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public int AvailableQuantity { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }


        public long SaleId { get; set; }
        public virtual Sale Sale { get; set; }

    }
}
