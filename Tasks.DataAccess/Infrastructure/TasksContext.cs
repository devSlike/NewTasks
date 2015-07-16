using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasks.DataAccess.Entities;

namespace Tasks.DataAccess.Infrastructure
{
    public class TasksContext : DbContext
    {
        public TasksContext()
            : base("TasksContext")
        {
            Database.SetInitializer<TasksContext>(new TasksBaseInitializer());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
    }
}