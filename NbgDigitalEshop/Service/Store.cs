using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using NbgDigitalEshop.Options;
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

         public bool AddArtifact(ArtifactOptions artifactOption)
        {    
            try {
                if (artifactOption.Price > 5000)
                    throw new ModelException("artifact too expensive");
                Artifact artifact = artifactOption.GetArtifact();
                _artifactRepository.Add(artifact);
                return true;
            }
            catch(Exception ) { 
                return false; 
            }
        }

        public bool Buy(Guid artifactGuid, Guid customerGuid)
        {
            throw new NotImplementedException();
        }

        public Guid Register(CustomerOptions customerOptions)
        {
            throw new NotImplementedException();
        }

        public Guid SearchContainsByName(string artifactName)
        {
            throw new NotImplementedException();
        }

        public Guid SignIn(CustomerOptions customerOptions)
        {
            throw new NotImplementedException();
        }

        public bool SignOut(CustomerOptions customerOptions)
        {
            throw new NotImplementedException();
        }

        public void Statistics()
        {
            throw new NotImplementedException();
        }
    }
}
