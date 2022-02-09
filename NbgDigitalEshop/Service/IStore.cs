using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Service
{
    public interface IStore
    {
        public bool SignIn(string username, string password);
        public bool SignOut(string username );
        public bool Register(string username, string password);

        public bool Buy(Artifact artifact);
        public Artifact SearchByName(string artifactName);

        public  bool AddArtifact(Artifact artifact);
    }
}
