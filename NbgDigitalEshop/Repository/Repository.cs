using NbgDigitalEshop.exception;
using NbgDigitalEshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbgDigitalEshop.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly List<T> _list;

        public Repository()
        {
            _list = new List<T>();
        }

        public virtual  Guid Add(T t)
        {
            if (t == null)
                throw new ModelException( "null entity ");
            t.Id = Guid.NewGuid(); 
            _list.Add(t);
            return t.Id;
        }

        public int Count()
        {
            return _list.Count;
        }

        public bool Delete(Guid id)
        {
            return _list.Remove(Get(id));
        }

         public IList<T> Get(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 50) pageSize = 20;

            return _list.Skip((pageCount - 1) * pageSize).Take(pageSize).ToList();
        }

        public T Get(Guid id)
        {
            T? t = _list.FirstOrDefault(x => x.Id == id);
            if (t == null)
            {
                throw new ModelException("Entity not found");
            }
            return t;
        }
        public abstract bool Update(Guid id, T t);
    }
}
 
