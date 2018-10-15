using Food.EntityFramework.Entities;

namespace Food.EntityFramework
{
    internal interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetItem(int id);
        void Add(TEntity item);
        void Delete(TEntity item);
        void Delete(int id);
        void Save();
    }
}
