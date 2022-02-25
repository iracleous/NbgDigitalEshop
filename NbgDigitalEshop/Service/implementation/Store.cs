using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using NbgDigitalEshop.Options;
using NbgDigitalEshop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Service.implementation
{
    public class Store : IStore
    {
        private readonly IRepository<Artifact, Guid> _artifactRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;

        public Store(IRepository<Artifact, Guid> artifactRepository, IRepository<Customer, Guid> customerRepository)
        {
            _artifactRepository = artifactRepository;
            _customerRepository = customerRepository;
        }

        public bool AddArtifact(ArtifactOptions artifactOption)
        {
            try
            {
                if (artifactOption.Price > 5000)
                    throw new ModelException("artifact too expensive");
                Artifact artifact = artifactOption.ToArtifact();
                _artifactRepository.Add(artifact);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Buy(Guid artifactGuid, Guid customerGuid)
        {
            try
            {
                Artifact artifact = _artifactRepository.Get(artifactGuid);
                _artifactRepository.Delete(artifactGuid);
                Customer customer = _customerRepository.Get(customerGuid);
                customer.Balance -= artifact.Price;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Guid Register(CustomerOptions customerOptions)
        {
            try
            {
                if (!customerOptions.Address.Equals("Athens"))
                    throw new OptionsException("No customers outside Athens are permitted");
                Customer customer = customerOptions.ToCustomer();
                _customerRepository.Add(customer);
                return customer.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Guid? SearchContainsByName(string artifactName)
        {
            IList<Guid> resultsGuid = _artifactRepository.SearchByName(artifactName);
            if (resultsGuid.Count > 0) return resultsGuid[0];
            else
                return null;
        }

        public Guid? SignIn(CustomerOptions customerOptions)
        {
            IList<Guid> resultsGuid = _customerRepository.SearchByName(customerOptions.Email);
            if (resultsGuid.Count > 0) return resultsGuid[0];
            else
                return null;
        }

        public bool SignOut(CustomerOptions customerOptions)
        {
            throw new NotImplementedException();
        }

        public void Statistics()
        {
            Console.WriteLine($"Customers no = {_customerRepository.Count()}");
            _customerRepository
                .Get(1, 50)
                .ToList()
                .ForEach(ce => Console.WriteLine($"{ce.Name}, {ce.Email}, {ce.Balance}"));
            Console.WriteLine($"Artifacts no = {_artifactRepository.Count()}");
            _artifactRepository
                .Get(1, 50)
                .ToList()
                .ForEach(ae => Console.WriteLine($"{ae.Name}, {ae.Price}"));
            Console.WriteLine("---------------------------------------------------\n");
        }
    }
}
