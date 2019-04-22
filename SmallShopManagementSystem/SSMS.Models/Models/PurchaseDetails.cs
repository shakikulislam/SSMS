using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SSMS.Models.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        //public virtual Supplier Supplier { get; set; }

        //public int SupplierId { get; set; }

        //[DisplayName("Products")]
        //public virtual Product Product { get; set; }
        public string Product { get; set; }
        //public int ProductId { get; set; }
        public string Code { get; set; }
        //[DisplayName("Manufactured Date")]
        public DateTime ManufacturedDate { get; set; }

        //[DisplayName("Expire Date")]
        public DateTime ExpireDate { get; set; }

        //[DisplayName("Purchased Quantity")]
        public int Quantity { get; set; }

        //[DisplayName("Unit Price")]
        public double UnitPrice { get; set; }

        //[DisplayName("Total Price")]
        public double TotalPrice { get; set; }

        //[DisplayName("Previous Cost Price")]
        public double PreviousCostPrice { get; set; }

        //[DisplayName("Previous MRP")]
        public double PreviousMrp { get; set; }

        //[DisplayName("New Cost Price")]
        public double NewCostPrice { get; set; }

        //[DisplayName("New MRP")]
        public double NewMrp { get; set; }
        //public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }


    }
}
