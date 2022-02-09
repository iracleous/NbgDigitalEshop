using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public class ArtifactRepository : Repository<Artifact>, IRepository<Artifact>
    {
        public override Guid Add(Artifact artifact)
        {
            if (artifact == null)
                throw new ModelException("null artifact");
            if (artifact.Name == null)
                throw new ModelException("null artifact name");
           

            return base.Add(artifact);
        }

        public override bool Update(Guid id, Artifact artifact)
        {
            try
            {
                Artifact artifactFromList = Get(id);
                artifactFromList.Price = artifact.Price;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
