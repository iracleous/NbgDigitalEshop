using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Service
{
    public interface ICsvManager
    {
        public List<Artifact> Load(string filename);
        public void Save(List<Artifact> artifacts ,string filename);
    }
}
