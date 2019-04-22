using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public int LoyalityPoint { get; set; }


        public virtual List<SaleDetails> PurchaseDetailses { get; set; }

    }
}
