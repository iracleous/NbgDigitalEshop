using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.exception
{
    public class CustomerException:Exception
    {
        public CustomerException(string description):base(description)
        {
              
        }
    }
}
