using DatabaseApplication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseApplication.Service
{
    public interface IRepository<T, K>
    {
        //CRUD

        public K Add(T t);
        public bool Update(K id, T t);
        public bool Delete(K id);
        public IList<T> Get(int pageCount, int pageSize);
        public Response<T> Get(K id);

        public IList<K> SearchByName(string name);
        public int Count();
    }
}
