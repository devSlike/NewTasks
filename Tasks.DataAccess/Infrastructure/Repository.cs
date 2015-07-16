using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Tasks.DataAccess.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext DataContext;
        protected readonly DbSet<T> DataSet;

        public Repository(DbContext dataContext)
        {
            DataContext = dataContext;
            DataSet = dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return DataSet;
        }

        public IEnumerable<T> All()
        {
            return DataSet.ToList();
        }

        public T Get(Int32 id)
        {
            return DataSet.FirstOrDefault(x => x.Id == id);
        }

        public T Get(Func<T, Boolean> predicate)
        {
            return DataSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            DataSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DataSet.Remove(entity);
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }

        public void Update(T entity)
        {
            //DataSet.Attach(entity);
            DataSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}