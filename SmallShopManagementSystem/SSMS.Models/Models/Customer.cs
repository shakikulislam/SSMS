using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SSMS.Models.Models
{
    public class Customer : IEnumerable
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

        

        [DisplayName("Loyality Point")]
        public string LoyalityPoint { get; set; }
        public byte[] Image { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        [NotMapped]
        public List<System.Web.Mvc.SelectListItem> CustomerLookUp { get; set; }
    }
}
