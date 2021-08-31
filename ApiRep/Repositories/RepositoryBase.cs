using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Models
{
    public abstract class RepositoryBase<T>: IRepository<T>
    {
        protected AppIndContext db;

        public RepositoryBase(AppIndContext db)
        {
            this.db = db;
        }

        public abstract IEnumerable<Object> GetAll();
        public abstract T Get(int id);
        public abstract void Create(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);
        public abstract void Save();

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
