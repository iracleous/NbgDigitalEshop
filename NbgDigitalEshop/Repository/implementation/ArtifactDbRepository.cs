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
        private readonly SqlConnection _conn;


        private readonly string update = "update Artifact set name = @name, price = @price  where id =@id ";
        private readonly string selectByPage = "select * from artifact order by id OFFSET @offset ROWS FETCH NEXT @top ROWS ONLY";
        private readonly string insertOne = "INSERT INTO Artifact(Name,Price) VALUES(@name,@price); SELECT SCOPE_IDENTITY()";
        private readonly string deleteOne = "delete from Artifact where id =@id ";
        private readonly string selectOne = "select * from artifact where id = @id";
        private readonly string selectCount = "select count(*) as count from Artifact";
        private readonly string selectByName = "select * from artifact where name like @name";

        public ArtifactDbRepository (SqlConnection conn)
        {
            _conn = conn;
        }

        public int Add(Artifact artifact)
        {
            string sql = insertOne;
            using SqlCommand cmde = new(sql, _conn);
            cmde.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = artifact.Name;
            cmde.Parameters.Add("@price", SqlDbType.Money).Value = artifact.Price;
            cmde.CommandType = CommandType.Text;
          
            return Convert.ToInt32(cmde.ExecuteScalar()) ;
        }

        public int Count()
        {
            string sql = selectCount;
            using SqlCommand cmde = new(sql, _conn);

           return Convert.ToInt32(cmde.ExecuteScalar());
        }

        public bool Delete(int id)
        {
            string sql = deleteOne;
            using SqlCommand cmd = new(sql, _conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.Text;
           int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }

        public IList<Artifact> Get(int pageCount, int pageSize)
        {
            var artifactList = new List<Artifact>();

            if (pageSize <= 0 || pageSize > 50) pageSize = 20;
            if(pageCount<= 0) pageCount = 1;

            string sql = selectByPage; 
            using SqlCommand cmd = new(sql, _conn);
           cmd.Parameters.Add("@top", SqlDbType.Int).Value = pageSize;
           cmd.Parameters.Add("@offset", SqlDbType.Int).Value = (pageCount-1)*pageSize;

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
            string sql = selectOne;
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
            string sql = selectByName;
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
            string sql = update;
            using SqlCommand cmd = new(sql, _conn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = t.Name;
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = t.Price;
            cmd.CommandType = CommandType.Text;
            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
