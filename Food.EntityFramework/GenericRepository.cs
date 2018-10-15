using Food.EntityFramework.Context;
using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Food.EntityFramework
{
    class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IQueryable All { get; }

        private DbSet<TEntity> Table => _foodDbContext.Set<TEntity>();
        private FoodDbContext _foodDbContext;

        public GenericRepository(FoodDbContext foodDbContext) {_foodDbContext = foodDbContext;}

        public TEntity GetItem(int id) => Table.Find(id);

        public void Create(TEntity item) { Table.Add(item); }

        public void Update(TEntity item) { _foodDbContext.Entry(item).State = EntityState.Modified; }

        public void Save() { _foodDbContext.SaveChanges(); }

        public void Add(TEntity item)
        {
            Table.Add(item);
            _foodDbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            var entity = Table.Find(item);
            if (entity != null) Table?.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if (entity != null) Table?.Remove(entity);
        }
    }
}
