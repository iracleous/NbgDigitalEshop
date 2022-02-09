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


IRepository<Artifact> artifactRepository = new ArtifactRepository();
artifactRepository.Add(new Artifact { Name = "DPI NFT", Price = 2000 });
artifactRepository.Add(new Artifact { Name = "Thomi NFT", Price = 3000 });

//discount for a specific page

IList<Artifact> artifacts = artifactRepository.Get(1, 50) ;
artifacts.ToList()
    .ForEach(itemArtifact => 
        artifactRepository.Update(itemArtifact.Id,
                        new Artifact { Price = itemArtifact.Price * 0.8m }));

IList<Artifact> newArtifacts = artifactRepository.Get(1, 50);

newArtifacts.ToList()
    .ForEach(itemArtifact => Console.WriteLine($"{itemArtifact.Name}, {itemArtifact.Price}"));
