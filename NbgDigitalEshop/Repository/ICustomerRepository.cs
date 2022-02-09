using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public interface ICustomerRepository
    {
        //CRUD

        public Guid AddCustomer(Customer customer);
        public bool UpdateCustomer(Guid customerId, decimal balance);
        public bool DeleteCustomer(Guid customerId);
        public List<Customer> GetCustomers();
        public Customer GetCustomer(Guid customerId);
        public int Count();
    }
}
