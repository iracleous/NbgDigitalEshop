using Moq;
using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using NbgDigitalEshop.Options;
using NbgDigitalEshop.Repository;
using NbgDigitalEshop.Repository.implementation;
using NbgDigitalEshop.Service;
using NbgDigitalEshop.Service.implementation;
using System;
using Xunit;

namespace NbgDigitalTest
{
    public class StoreTest
    {
        

        [Fact]
        public void BuyTest()
        {

            var customerData = new CustomerOptions
            {
                FirstName = "D",
                LastName = "X",
                Email = "xx@gg.gr",
                Address = "Athens",
                Password = "xx"
            };


            IRepository<Customer, Guid> customerRepository = new CustomerRepository();
            IRepository<Artifact, Guid> artifactRepository = new ArtifactRepository();

            IStore store = new Store(artifactRepository, customerRepository);

            Guid customerGuid = store.Register(customerData);
            Guid artifactGuid = Guid.NewGuid();

            bool buy = store.Buy(artifactGuid, customerGuid);

            Assert.False(buy);
        }

        [Theory]
        [InlineData("Thessaloniki")]
        [InlineData("Lamia")]
        [InlineData("Athens")]

        public void RegisterTest(string city)
        {
            var customerData = new CustomerOptions
            {
                FirstName = "D",
                LastName = "X",
                Email = "xx@gg.gr",
                Address = city,
                Password = "xx"
            };

            IRepository<Customer, Guid> customerRepository = new CustomerRepository();
            IRepository<Artifact, Guid> artifactRepository = new ArtifactRepository();

            IStore store = new Store(artifactRepository, customerRepository);

              var caughtException = Record.Exception( () 
                =>  store.Register(customerData) );

            if (city == "Athens")
            {
                Assert.Null(caughtException);
            }

            else
            {
                Assert.Equal("No customers outside Athens are permitted",
                    caughtException.Message);
            }
        }


        public Mock<IRepository<Customer, Guid>> mockCustomerRepo =
            new();
        public Mock<IRepository<Artifact, Guid>> mockArtifactRepo =
                    new();
        [Fact]
        public void BuyTestWithMoqRepos()
        {
            var customer = new Customer
            {
                Name = "D",
                Email = "xx@gg.gr",
                Address = "Athens",
                Password = "xx",
                Balance = 0
            };

            Guid customerGuid = Guid.NewGuid();
            Guid artifactGuid = Guid.NewGuid();

            mockCustomerRepo.Setup(p => p.Get(customerGuid)).Returns(customer);
            mockArtifactRepo.Setup(p => p.Get(artifactGuid)).Returns(
                new Artifact() { Price=10});
            mockArtifactRepo.Setup(p => p.Delete(artifactGuid));

            IStore store = new Store(mockArtifactRepo.Object, 
                mockCustomerRepo.Object);

            bool buy = store.Buy(artifactGuid, customerGuid);

            Assert.Equal(customer.Balance, -10);
        }

    }
}