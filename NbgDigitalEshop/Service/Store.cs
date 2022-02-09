using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Service
{
    public class Store : IStore
    {
        private readonly IRepository<Artifact> _artifactRepository;
        private readonly IRepository<Customer> _customerRepository;

    public Store(IRepository<Artifact> artifactRepository, IRepository<Customer> customerRepository)
        {
            _artifactRepository = artifactRepository;
            _customerRepository = customerRepository;
        }

        public bool AddArtifact(Artifact artifact)
        {
            try {
                if (artifact.Price > 5000)
                    throw new ModelException("artifact too expensive");
                _artifactRepository.Add(artifact);
                return true;
            }
            catch(Exception ) { 
                return false; 
            }
        }

        public bool Buy(Artifact artifact)
        {
            throw new NotImplementedException();
        }

        public bool Register(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Artifact SearchByName(string artifactName)
        {
            throw new NotImplementedException();
        }

        public bool SignIn(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool SignOut(string username)
        {
            throw new NotImplementedException();
        }
    }
}
