using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.exception
{
    

    public class OptionsException : Exception
    {
        public string Message { get; set; }
        public OptionsException(string description) : base(description)
        {
            Message = description;
        }
    }

}
