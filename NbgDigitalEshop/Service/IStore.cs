using NbgDigitalEshop.Model;
using NbgDigitalEshop.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Service
{
    public interface IStore
    {
        public Guid SignIn(CustomerOptions customerOptions);
        public bool SignOut(CustomerOptions customerOptions);
        public Guid Register(CustomerOptions customerOptions);

        public bool Buy(Guid artifactGuid, Guid customerGuid);
        public Guid SearchContainsByName(string artifactName);

        public  bool AddArtifact(ArtifactOptions artifact);

        public void Statistics();
    }
}
