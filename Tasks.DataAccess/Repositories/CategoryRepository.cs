using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasks.DataAccess.Entities;
using Tasks.DataAccess.Infrastructure;

namespace Tasks.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DbContext dataContext)
            : base(dataContext)
        { }
    }

    public interface ICategoryRepository
    {
        void SaveChanges();
    }
}