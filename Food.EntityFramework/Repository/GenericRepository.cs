﻿using Food.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Food.EntityFramework
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TEntity> All { get; }

        private DbSet<TEntity> Table => _foodDbContext.Set<TEntity>();
        private readonly FoodDbContext _foodDbContext;

        public GenericRepository(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
            All = Table;
        }

        public TEntity GetItem(int id) => Table.Find(id);

        public TEntity Save(TEntity item)
        {
            TEntity savedEntity = item.Id == 0 
                ? Table.Add( item ).Entity 
                : Table.Update( item ).Entity;

            _foodDbContext.SaveChanges();

            return savedEntity;
        }

        public void Delete(TEntity item)
        {
            var entity = Table.Find(item);
            if (entity != null)
            {
                Table.Remove(entity);
                _foodDbContext.SaveChanges();
            }
        }

        public void Delete(IEnumerable<TEntity> items)
        {
            foreach( TEntity item in items)
            {
                var entity = Table.Find(item);
                if (entity != null)
                {
                    Table.Remove(entity);
                }
            }
            _foodDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if (entity != null)
            {
                Table.Remove(entity);
                _foodDbContext.SaveChanges();
            }
        }
    }
}
