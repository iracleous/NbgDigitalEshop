using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Model
{
    public class Artifact: BaseModel
    {
        public string? Name { get; set; }
        public int? Code { get; set; }
        public string? ArtifactDescription { get; set;}
        public decimal Price { get; set; }
        public string? ImageFileName { get; set;}
    }
}
