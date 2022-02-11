using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Options
{
    
      public class ArtifactOptions
    {
        public string? Name { get; set; }

        public string? ArtifactDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageFileName { get; set; }


        public Artifact GetArtifact()
        {
            return new Artifact
            {
                Name = Name,
                ArtifactDescription = ArtifactDescription,
                Price = Price,
                ImageFileName = ImageFileName,
            };
        }
    }
}
