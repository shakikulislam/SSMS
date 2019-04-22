using System.Collections.Generic;
using System.ComponentModel;

namespace SSMS.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }

        [DisplayName ("Contact Person")]
        public string ContactPerson { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
      

    }
}