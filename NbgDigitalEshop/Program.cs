using NbgDigitalEshop.Model;
using NbgDigitalEshop.Service;
using System.Data.SqlClient;


/*
ICsvManager reader = new CsvManager();
string filename = "myfile.scv";
string outputFilename = "myfile.out.scv";

List<Artifact> artifacts = reader.Load(filename); 

artifacts.ForEach(a => Console.WriteLine(a.Name));
artifacts.ForEach(a => a.Price *= 1.1m);

reader.Save(artifacts, outputFilename);
*/

List<Artifact> artifacts = new();
artifacts.Add(new Artifact { ArtifactDescription = "statue", Price = 200m }); 
artifacts.Add(new Artifact { ArtifactDescription = "painting", Price = 200m });

//initialize all classes
using  SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=passw0rd;database=NbgAccountSystem");
conn.Open();
SqlCommand cmd = new SqlCommand("select * from customer", conn);
 
using (SqlDataReader reader = cmd.ExecuteReader())
{
    while (reader.Read())
    {
 
        Console.WriteLine ($"id = {reader["id"]} name = { reader["name"]}");
    }
}

 


