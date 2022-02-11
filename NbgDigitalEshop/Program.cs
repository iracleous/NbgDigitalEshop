using NbgDigitalEshop.Model;
using NbgDigitalEshop.Service;



ICsvManager reader = new CsvManager();
string filename = "myfile.scv";
string outputFilename = "myfile.out.scv";

List<Artifact> artifacts = reader.Load(filename); 

artifacts.ForEach(a => Console.WriteLine(a.Name));
artifacts.ForEach(a => a.Price *= 1.1m);

reader.Save(artifacts, outputFilename);