using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository.implementation
{
    public class ArtifactDbRepository : IRepository<Artifact, int>
    {
        private SqlConnection _conn;

        public ArtifactDbRepository (SqlConnection conn)
        {
            _conn = conn;
        }

        public int Add(Artifact artifact)
        {
            string sql = "INSERT INTO Artifact(Name,Price) VALUES(@name,@price); SELECT SCOPE_IDENTITY()";
            using SqlCommand cmde = new(sql, _conn);
            cmde.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = artifact.Name;
            cmde.Parameters.Add("@price", SqlDbType.Money).Value = artifact.Price;
            cmde.CommandType = CommandType.Text;
          
            return Convert.ToInt32(cmde.ExecuteScalar()) ;
        }

        public int Count()
        {
            string sql = "select count(*) as count from Artifact";
            using SqlCommand cmde = new(sql, _conn);

           return Convert.ToInt32(cmde.ExecuteScalar());

        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Artifact> Get(int pageCount, int pageSize)
        {
            var artifactList = new List<Artifact>(); 
            string sql = "select * from artifact";
            using SqlCommand cmd = new(sql, _conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                artifactList.Add(new Artifact()
                {
                    Code = Convert.ToInt32(reader["id"]),
                    Name = Convert.ToString( reader["name"])
                });
            }
            return artifactList;
        }

        public Artifact Get(int id)
        {
            var artifact = new Artifact();
            string sql = "select * from artifact where id = @id";
            using SqlCommand cmd = new(sql, _conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            using SqlDataReader reader = cmd.ExecuteReader();
            bool found = false;
            while (reader.Read())
            {
                found = true;
                artifact.Code = Convert.ToInt32(reader["id"]);
                artifact.Name = Convert.ToString(reader["name"]);
            
            }
            if (found) return artifact;
            else throw new ModelException("artifact not found");
        }

        public IList<int> SearchByName(string name)
        {
            var artifactIdList = new List<int>();
            string sql = "select * from artifact where name like @name";
            using SqlCommand cmd = new(sql, _conn);
            cmd.Parameters.Add("@name", SqlDbType.VarChar,50).Value = "%" + name + "%";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                artifactIdList.Add(  Convert.ToInt32(reader["id"])  );
            }
            return artifactIdList;
        }

        public bool Update(int id, Artifact t)
        {
            throw new NotImplementedException();
        }
    }
}
