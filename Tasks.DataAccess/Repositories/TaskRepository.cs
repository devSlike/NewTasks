using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasks.DataAccess.Entities;
using Tasks.DataAccess.Infrastructure;

namespace Tasks.DataAccess.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext dataContext)
            : base(dataContext)
        { }
    }

    public interface ITaskRepository
    {
    }
}