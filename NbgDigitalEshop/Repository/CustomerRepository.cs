using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
         
  
        public override Guid Add(Customer customer)
        {
            if (customer == null)
                throw new ModelException("null customer");
            if (customer.Address == null)
                throw new ModelException("null address");
            if (!customer.Address.Equals("Athens"))
                throw new ModelException("Customer's address is not Athens");
           
            return base.Add(customer);
        }
 

        public override bool Update(Guid customerId, Customer customer)
        {
            try
            {
                Customer customerFromList = Get(customerId);
                customerFromList.Balance = customer.Balance;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
