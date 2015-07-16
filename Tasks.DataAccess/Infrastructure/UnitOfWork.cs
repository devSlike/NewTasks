using System;
using Tasks.DataAccess.Repositories;

namespace Tasks.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TasksContext _dataContext = new TasksContext();

        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            return new Repository<T>(_dataContext);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}