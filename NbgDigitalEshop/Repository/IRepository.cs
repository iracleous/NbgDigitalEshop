using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public interface IRepository<T> 
    {
        //CRUD

        public Guid Add(T t);
        public bool Update(Guid id, T t);
        public bool Delete(Guid id);
        public IList<T> Get(int pageCount, int pageSize);
        public T Get(Guid id);
        public int Count();
    }
}
