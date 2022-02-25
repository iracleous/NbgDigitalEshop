using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Algorithms
{
    public class Discount
    {
        public decimal InitialValue { get; set; }
        
        public decimal CalculateDiscount(int quantity)
        {
            if (quantity <= 5)
                return 0m * InitialValue;
            else if (quantity <= 10)
                return 0.05m * InitialValue;
            else return 0.1m * InitialValue;
        }

    }
}
