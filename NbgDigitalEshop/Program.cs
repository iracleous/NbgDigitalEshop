using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;

var customer = new Customer { Name = "Manthos", Address = "Athens", DateOnly = new DateOnly() };


IRepository< Customer> customerRepository = new CustomerRepository();
customerRepository.Add(customer);
Console.WriteLine($"The number of customers is {customerRepository.Count()}");


var anotherCustomer = new Customer { Name = "John", Address="Lamia" };
IList<Customer> customers = customerRepository.Get(1, 50);

customers.ToList().ForEach(eachCustomer =>
            Console.WriteLine($"customer {eachCustomer.Id} = {eachCustomer.Name}"));



try {customerRepository.Add(anotherCustomer); }
catch (Exception ex) { Console.WriteLine(ex.Message); }


Console.WriteLine($"The number of customers is {customerRepository.Count()}");

