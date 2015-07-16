using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasks.DataAccess.Entities;
using Tasks.DataAccess.Infrastructure;

namespace Tasks.DataAccess.Repositories
{
    public class SubTaskRepository : Repository<SubTask>, ISubTaskRepository
    {
        public SubTaskRepository(DbContext dataContext)
            : base(dataContext)
        { }
    }

    public interface ISubTaskRepository
    {
    }
}