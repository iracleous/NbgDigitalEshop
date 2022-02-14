using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Options
{
    public class CustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public Customer ToCustomer()
        {
            return new Customer
            {
                Name = FirstName + " " + LastName,
                Address = Address,
                Balance = 0m,
                Email = Email,
                Password = Password
            };
        }
    }
}
