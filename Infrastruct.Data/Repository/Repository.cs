using DomainDriving.Domains.Interfaces;
using Infrastruct.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastruct.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly StudyContext _studyContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(StudyContext context)
        {
            _studyContext = context;
            _dbSet = context.Set<TEntity>();
     
        }
        public void Add(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Dispose()
        {
            _studyContext.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            _dbSet.Remove(_dbSet.Find(id));
        }

        public int SaveChanges()
        {
            return _studyContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dbSet.Update(obj);
        }
    }
}
