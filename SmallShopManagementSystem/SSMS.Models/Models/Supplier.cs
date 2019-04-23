using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SSMS.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]

        [DisplayName ("Contact Person")]
        public string ContactPerson { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
      

    }
}