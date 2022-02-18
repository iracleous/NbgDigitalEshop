
using DatabaseApplication.DbConn;
using DatabaseApplication.model;
using DatabaseApplication.Service;

Customer customer = new Customer
{
    Name = "Nikos",
    Address = "Lamia",
    DateOfBirth = new DateTime(1900, 12, 1),
    OrdersNumber = 5000,
};




try
{
    using NbgDbContext db = new();
    int x = db.Customers.Count();
    CustomerRepository customerRepository   = new CustomerRepository(db);


    Console.WriteLine($"customers number is " + customerRepository.Count());

    Console.WriteLine(customerRepository.Get(2).Data.Name);

    //Console.WriteLine($"customer id before saving to db = {customer.Id}");
    //customerRepository.Add(customer);
    //Console.WriteLine($"customer id after saving to db = {customer.Id}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}



