using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SSMS.Models.Models
{
    public class Purchase 
    {
        public int Id { get; set; }

        //[Required]
        public DateTime Date { get; set; }

        //[Required]
        //[DisplayName("Bill/Invoice No.")]
        public string Bill { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<PurchaseDetails> PurchaseDetailses { get; set; }

        //[NotMapped]
        //public List<SelectListItem> SupplierLookUp { get; set; }


        //[NotMapped]
        //public List<SelectListItem> ProductLookUp { get; set; }

        //public virtual List<PurchaseFile> PurchaseFiles { get; set; }

        //public int Id { get; set; }
        //[Required]
        //public DateTime Date { get; set; }
        //[Required]
        //[DisplayName("Bill/Invoice No.")]
        //public string Bill { get; set; }

        //public virtual Supplier Supplier { get; set; }

        //public int SupplierId { get; set; }

        //[DisplayName("Products")]
        //public virtual Product Product { get; set; }
        //public int ProductId { get; set; }
        //public string Code { get; set; }
        //[DisplayName("Manufactured Date")]
        //public DateTime ManufacturedDate { get; set; }

        //[DisplayName("Expire Date")]
        //public DateTime ExpireDate { get; set; }

        //[DisplayName("Purchased Quantity")]
        //public int Quantity { get; set; }

        //[DisplayName("Unit Price")]
        //public double UnitPrice { get; set; }

        //[DisplayName("Total Price")]
        //public double TotalPrice { get; set; }

        //[DisplayName("Previous Cost Price")]
        //public double PreviousCostPrice { get; set; }

        //[DisplayName("Previous MRP")]
        //public double PreviousMrp { get; set; }

        //[DisplayName("New Cost Price")]
        //public double NewCostPrice { get; set; }

        //[DisplayName("New MRP")]
        //public double NewMrp { get; set; }

        //[NotMapped]
        //public List<SelectListItem> SupplierLookUp { get; set; }


        //[NotMapped]
        //public List<SelectListItem> ProductLookUp { get; set; }


       
    }
}
