using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;

var customer = new Customer { Name = "Manthos", Address = "Athens", DateOnly = new DateOnly() };


ICustomerRepository customerRepository = new CustomerRepository();
customerRepository.AddCustomer(customer);
Console.WriteLine($"The number of coustomers is {customerRepository.Count()}");


var anotherCustomer = new Customer { Name = "John", Address="Lamia" };
IList<Customer> customers = customerRepository.GetCustomers();
customers.Add(anotherCustomer);


try {customerRepository.AddCustomer(anotherCustomer); }
catch (Exception ex) { Console.WriteLine(ex.Message); }


Console.WriteLine($"The number of coustomers is {customerRepository.Count()}");

