using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customerList;

        public CustomerRepository()
        {
            _customerList = new List<Customer>();
        }

        public Guid AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new CustomerException("null customer");
            var customerId = new Guid();
            customer.CustomerId = customerId;
            _customerList.Add(customer);
            return customerId;
        }

        public bool DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCustomer(Guid customerId, decimal balance)
        {
            throw new NotImplementedException();
        }
    }
}
