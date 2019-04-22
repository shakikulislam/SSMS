
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

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Bill/Invoice No.")]
        public string Bill { get; set; }

        public virtual Supplier Supplier { get; set; }
        public int SupplierId { get; set; }

        public virtual Product Product { get; set; }
        public string ProductCode { get; set; }
        //public int ProductId { get; set; }

        public virtual ICollection<PurchaseDetails> PurchaseDetailses { get; set; }

        [NotMapped]
        public List<SelectListItem> SupplierLookUp { get; set; }


        [NotMapped]
        public List<SelectListItem> ProductLookUp { get; set; }

      
       
    }
}
