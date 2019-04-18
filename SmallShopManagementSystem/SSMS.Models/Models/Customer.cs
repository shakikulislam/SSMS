using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SSMS.Models.Models
{
    public class Customer : IEnumerable
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
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
