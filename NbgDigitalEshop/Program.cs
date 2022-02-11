//use case

using NbgDigitalEshop.Model;
using NbgDigitalEshop.Options;
using NbgDigitalEshop.Repository;
using NbgDigitalEshop.Service;


// data from input forms
var customerData = new CustomerOptions
{
    FirstName = "D",
    LastName = "X",
    Email = "xx@gg.gr",
    Address = "Athens",
    Password = "xx"
};

var artifactMedium = new ArtifactOptions { Name = "DPI NFT", Price = 2000 };
var artifactHi = new ArtifactOptions { Name = "Thomi NFT", Price = 3000 };

IRepository< Customer> customerRepository = new CustomerRepository();
IRepository<Artifact> artifactRepository = new ArtifactRepository();


IStore store = new Store(artifactRepository, customerRepository);


// Use case 1.  add artifacts to store
store.AddArtifact(artifactMedium);
store.AddArtifact(artifactHi);


// Use case 2.  user registers
store.Register(customerData);


//Use case 3. user buys
store.Statistics();
var customerGuid = store.SignIn(customerData);
var artifactGuid = store.SearchContainsByName("NFT");
if (artifactGuid != null && customerGuid != null)
    store.Buy(artifactGuid.Value, customerGuid.Value);
store.Statistics();
 