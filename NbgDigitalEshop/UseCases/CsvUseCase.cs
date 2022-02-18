using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;
using NbgDigitalEshop.Repository.implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.UseCases
{
    public class CsvUseCase
    {
        public void UseCase()
        {
            var artifactOne = new Artifact { Name = "statue", Price = 200m };
            var artifactTwo = new Artifact { Name = "painting", Price = 300m };

            //three alternative implementations of a repo

            //csv
            string artifactFilename = @"C:\dimitris\datafiles\artifacts.csv";
            IRepository<Artifact, Guid> repository = new ArtifactCsvRepository(artifactFilename);

            //memory
            //IRepository<Artifact, Guid> repository = new ArtifactRepository();


            //sql
            //using SqlConnection conn = new("Server=localhost; Database=NbgAccountSystem; Integrated Security=true ");
            //conn.Open();
            //IRepository<Artifact, int> repository = new ArtifactDbRepository(conn);



            /// <summary>
            /// ------------------Same code for UI
            /// </summary>

            //UI

            repository.Add(artifactOne);
            repository.Add(artifactTwo);

            Console.WriteLine(repository.Count());

            List<Artifact> artifacts = repository.Get(1, 20).ToList();
            artifacts.ForEach(artifact =>
                Console.WriteLine($"id = {artifact.Id}, " +
                $"name = {artifact.Name}, price = {artifact.Price}"));
        }

    }
}
