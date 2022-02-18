using NbgDigitalEshop.Model;
using NbgDigitalEshop.Repository;
using NbgDigitalEshop.Repository.implementation;
using NbgDigitalEshop.Service;
using System.Data;
using System.Data.SqlClient;


namespace NbgDigitalEshop.UseCases
{
    public class DbUseCase
    {
        public void UseCase()
        {


            /*
            ICsvManager reader = new CsvManager();
            string filename = "myfile.scv";
            string outputFilename = "myfile.out.scv";

            List<Artifact> artifacts = reader.Load(filename); 

            artifacts.ForEach(a => Console.WriteLine(a.Name));
            artifacts.ForEach(a => a.Price *= 1.1m);

            reader.Save(artifacts, outputFilename);
            */
            Artifact artifactOne = new Artifact { Name = "statue", Price = 200m };
            Artifact artifactTwo = new Artifact { Name = "painting", Price = 300m };
            List<Artifact> artifacts = new();
            artifacts.Add(artifactOne);
            artifacts.Add(artifactTwo);


            //initialize all classes
            //using  SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=passw0rd;database=NbgAccountSystem");
            using SqlConnection conn = new("Server=localhost; Database=NbgAccountSystem; Integrated Security=true ");

            conn.Open();

            IRepository<Artifact, int> artifactDbRepository = new ArtifactDbRepository(conn);

            //int newId = artifactDbRepository.Add(artifactOne);
            //Console.WriteLine($"The inserted id is {newId}");

            IList<Artifact> artifactList = artifactDbRepository.Get(1, 20);
            artifactList.ToList().ForEach(x => Console.WriteLine($"Code = {x.Code} Name = {x.Name}"));

            Console.WriteLine($"The number of artifacts in the db is {artifactDbRepository.Count()}");

            var artifactIdList = artifactDbRepository.SearchByName("statue");
            artifactIdList.ToList().ForEach(x => Console.WriteLine($"Artifact id = {x}"));

            artifactDbRepository.Update(1, artifactTwo);
            Artifact artifactThree = artifactDbRepository.Get(1);
            Console.WriteLine($"name = {artifactThree.Name} id = {artifactThree.Code} price = {artifactThree.Price}");

            IList<Artifact> artifactList2 = artifactDbRepository.Get(1, 20);
            artifactList2.ToList().ForEach(x => Console.WriteLine($"Code = {x.Code} Name = {x.Name}"));




        }

    }
}
