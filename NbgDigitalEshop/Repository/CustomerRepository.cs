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
            if (customer.Address == null)
                throw new CustomerException("null address");
            if (!customer.Address.Equals("Athens"))
                throw new CustomerException("Customer's address is not Athens");
            var customerId = new Guid();
            customer.CustomerId = customerId;
            _customerList.Add(customer);
            return customerId;

        }

        public int Count()
        {
            return _customerList.Count;
        }

        public bool DeleteCustomer(Guid customerId)
        {
            // 1
            /*
          Customer? customerFound = null;
          foreach (Customer customer in _customerList)
            {
                if (customer.CustomerId == customerId)
                {
                    customerFound = customer;
                }
            }
          if (customerFound != null) {
                  _customerList.Remove(customerFound);
                return true;
            }
          return false;
            */
            //2
           /*
            
            Customer? customerFound = GetCustomer(customerId);
            if (customerFound != null)
            {
                return _customerList.Remove(customerFound);
            }
            return false;
     */
        return _customerList.Remove(GetCustomer(customerId));
        }

        public Customer GetCustomer(Guid customerId)
        {
            Customer? customer =_customerList.FirstOrDefault(x => x.CustomerId == customerId);
            if (customer == null)
            {
                throw new CustomerException("Customer not found");
            }
            return customer;
        }


        public List<Customer> GetCustomers()
        {
            return _customerList.ToList();
        }

        public bool UpdateCustomer(Guid customerId, decimal balance)
        {
            try
            {
                Customer customer = GetCustomer(customerId);
                customer.Balance = balance;
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
