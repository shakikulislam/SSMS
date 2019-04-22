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
    public class Product 
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Reorder Level")]
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [NotMapped]
        public List<SelectListItem> CategoryLookUp { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

    }
}
