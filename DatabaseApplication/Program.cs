
using DatabaseApplication.DbConn;
using DatabaseApplication.model;
using DatabaseApplication.Responses;
using DatabaseApplication.Service;

Customer customer = new Customer
{
    Name = "Dimitris",
    Address = "Lamia",
    DateOfBirth = new DateTime(1900, 12, 1),
    OrdersNumber = 5000,
};


Customer customerSecond = new Customer
{
    Name = "Fanis",
    Address = "Patras",
    DateOfBirth = new DateTime(1980, 12, 1),
    OrdersNumber = 1000,
};

try
{
    using NbgDbContext db = new();
    CustomerRepository customerRepository   = new CustomerRepository(db);


  bool runAll =   customerRepository.Delete(2) &&
    customerRepository.Delete(3) &&
    customerRepository.Delete(7) &&
    customerRepository.Delete(4) && customerRepository.Delete(5);

    if (runAll) Console.WriteLine("All has run");


//   bool run = customerRepository.Update(30, customerSecond);
//    if (!run) Console.WriteLine("No update has taken place");

    //   var customerIds = customerRepository.SearchByName("Dimitris");
    //  Console.WriteLine("# customers is " + customerIds.Count());



}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}



