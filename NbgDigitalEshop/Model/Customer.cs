using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Model
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateOnly DateOnly { get; set; }

        public decimal? Balance { get; set; }
    }
}
