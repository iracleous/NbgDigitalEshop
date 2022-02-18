using DatabaseApplication.DbConn;
using DatabaseApplication.model;
using DatabaseApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Service
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        private NbgDbContext db;
        public CustomerRepository(NbgDbContext db)
        {
            this.db = db;
        }
        public int Add(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.Id;
        }

        public int Count()
        {
            return db.Customers.Count();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> Get(int pageCount, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Response<Customer> Get(int id)
        {
           Customer? customer = db.Customers.Find(id);
           return (customer!= null) ? 
                new Response<Customer>
               {
                   Code = 200,
                   Message = "The customer has been found",
                   Data = customer
               }
            : new Response<Customer>
               {
                   Code = 404,
                   Message = "The customer has NOT been found",
                   Data = null
               };
        }

        public IList<int> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
