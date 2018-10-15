using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Food.EntityFramework
{
    abstract class Repository<C,T>:IRepository<T>,IDisposable where C: DbContext where T:class
    {
        private C _dbContext;
        public abstract IEnumerable<T> GetList();
        public abstract T GetItem(int id);
        public abstract void Create(T item);
        public abstract void Update(T item);
        public abstract void Delete(T item);
        public abstract void Delete(int id);
        public abstract void Save();
        public abstract void Dispose();
    }
}
