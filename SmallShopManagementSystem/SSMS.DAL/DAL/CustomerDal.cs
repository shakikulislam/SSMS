using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSMS.DatabaseContext.DatabaseContext;
using SSMS.Models.Models;

namespace SSMS.DAL.DAL
{
   public class CustomerDal
    {
        
        SSMSDbContext _db = new SSMSDbContext();

        public bool Add(Customer customer)
        {
            bool saved = false;
            _db.Customrs.Add(customer);
            var isSaved = _db.SaveChanges();
            if (isSaved > 0)
            {
                saved = true;
            }
            else
            {
                saved = false;
            }

            return saved;
        }

    }
    }

