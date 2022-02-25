﻿using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;
using NbgDigitalEshop.Repository.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NbgDigitalTest
{
    public class CustomerRepositoryTest
    {
        [Theory]
        [InlineData("Nick")]
        [InlineData("John")]
        [InlineData("Dimitris")]
        [InlineData("Maria")]    
        public void SearchByNameTest(string? name)
        {
            IRepository<Customer, Guid> customerRepository = 
                new CustomerRepository();
            customerRepository.Add(new Customer { 
                Name = "Dimitris", Address = "Athens"});

            var list = customerRepository.SearchByName(name);
            Assert.NotNull(list);
            if (name=="Dimitris" )
                Assert.Equal(1, list.Count);
            else
                Assert.Equal(0, list.Count);
        }
    }
}
