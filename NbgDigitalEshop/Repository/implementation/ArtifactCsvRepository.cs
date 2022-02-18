using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository.implementation
{
    public class ArtifactCsvRepository : IRepository<Artifact, Guid>
    {

        private readonly string _filename;

        public ArtifactCsvRepository(string filename)
        {
            _filename = filename;
            if (!File.Exists(filename))
               File.Create(filename).Close();
        }

        public Guid Add(Artifact t)
        {
            if (t == null || !File.Exists(_filename))
            {
                throw new Exception("Invalid artifact or artifact file");
            }

            t.Id = Guid.NewGuid();
            using StreamWriter sw = File.AppendText(_filename);
            sw.WriteLine( $"{t.Id},{t.Name},{t.Price}");
            return t.Id;
        }

        public int Count()
        {
            if (  !File.Exists(_filename))
            {
                throw new Exception("  artifact file not exists");
            }
            string[] lines = File.ReadAllLines(_filename);
            return lines.Length;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Artifact> Get(int pageCount, int pageSize)
        {
            if (pageSize <= 0 || pageSize > 50) pageSize = 20;
            if (pageCount <= 0) pageCount = 1;

            if (!File.Exists(_filename))
            {
                throw new Exception("  artifact file not exists");
            }
            IList<Artifact> artifactList = new List<Artifact>();
            string[] rows = File.ReadAllLines(_filename);

            rows.ToList()
                .Skip((pageCount-1)*pageSize)
                .Take(pageSize)
                .ToList()
                .ForEach(row =>
                {
                    var columns = row.Split(",");
                    artifactList.Add(
                        new Artifact {  
                            Id = Guid.Parse(columns[0]), 
                            Name = Convert.ToString(columns[1]), 
                            Price = Convert.ToDecimal(columns[2])
                        });
                });
            return artifactList;
        }

        public Artifact Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Guid> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, Artifact t)
        {
            throw new NotImplementedException();
        }
    }
}
