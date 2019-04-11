using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSMS.Models.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        //public Category Category { get; set; }

        public string Category { get; set; }

        [DisplayName("Reorder Level")]
        public int ReorderLevel { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
