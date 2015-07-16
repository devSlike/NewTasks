using System;
using Tasks.DataAccess.Repositories;

namespace Tasks.DataAccess.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;

        void SaveChanges();
    }
}