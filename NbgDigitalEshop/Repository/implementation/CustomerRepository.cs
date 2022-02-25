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

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public override IList<Guid> SearchByName(string name)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
           if (name == null) return new List<Guid>();
            return _list
              .Where(x => x.Name != null && x.Name.Contains(name))
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
