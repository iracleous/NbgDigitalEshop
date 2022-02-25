using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository.implementation
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer, Guid>
    {

        public override Guid Add(Customer customer)
        {
            // to do unique emails

            if (customer == null)
                throw new ModelException("null customer");
            if (customer.Address == null)
                throw new ModelException("null address");
            customer.DateOnly = new DateOnly();
            return base.Add(customer);
        }

        public override IList<Guid> SearchByName(string name)
        {
            return _list
              .Where(x => x.Email != null && x.Email.Contains(name))
              .Select(x => x.Id)
              .ToList();
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
