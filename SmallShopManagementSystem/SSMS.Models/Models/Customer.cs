using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
using System.ComponentModel.DataAnnotations.Schema;
>>>>>>> 09a3301de4e64208b5fec0e2b2bb41ba6d79129b
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
