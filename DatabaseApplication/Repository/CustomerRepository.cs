using DatabaseApplication.DbConn;
using DatabaseApplication.model;
using DatabaseApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Repository
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
            Customer? customer = db.Customers.Find(id);
            if (customer == null) return false;
            db.Customers.Remove(customer);
            db.SaveChanges();
            return true;
        }

        public IList<Customer> Get(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 50) pageSize = 20;

            return db.Customers.Skip((pageCount - 1) * pageSize).Take(pageSize).ToList();
        }

        public Response<Customer> Get(int id)
        {
            Customer? customer = db.Customers.Find(id);
            return customer != null ?
                 new Response<Customer>
                 {
                     Code = Response<Customer>.FoundCode,
                     Message = "The customer has been found",
                     Data = customer
                 }
             : new Response<Customer>
             {
                 Code = Response<Customer>.NotFoundCode,
                 Message = "The customer has NOT been found",
                 Data = null
             };
        }

        public IList<int> SearchByName(string name)
        {

            //check for performance

            return db.Customers
            //    .Where(customer => customer.Name !=null  && customer.Name.Contains(name)  )
               .Where(customer => customer.Name.Contains(name))

                 //       .Where(customer => (""+customer.Name).Contains(name))
                 .Select(customer => customer.Id)
                 .ToList();
        }

        public bool Update(int id, Customer customer)
        {
            Customer? customerInDb = db.Customers.Find(id);
            if (customerInDb == null)
            {
                return false;
            }
            customerInDb.Name = customer.Name;
            customerInDb.Address = customer.Address;
            customerInDb.DateOfBirth = customer.DateOfBirth;
            customerInDb.Balance = customer.Balance;
            customerInDb.OrdersNumber = customer.OrdersNumber;
            db.SaveChanges();
            return true;
        }
    }
}
