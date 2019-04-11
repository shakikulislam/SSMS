using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SSMS.Models.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        [DisplayName("Loyality Point")]
        public string LoyalityPoint { get; set; }
        public byte[] Image { get; set; }
    }
}
