using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tasks.DataAccess.Entities;

namespace Tasks.DataAccess.Infrastructure
{
    public class TasksBaseInitializer : DropCreateDatabaseIfModelChanges<TasksContext>
    {
        protected override void Seed(TasksContext context)
        {
            Categories().ForEach(x => context.Categories.Add(x));
            Tasks().ForEach(x => context.Tasks.Add(x));
            SubTasks().ForEach(x => context.SubTasks.Add(x));
        }

        private static List<Category> Categories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Tasks for Monday"
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Tasks for Tuesday"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Tasks for Wednesday"
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Tasks for Thursday"
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Tasks for Friday"
                }
            };
            return categories;
        }

        private static List<Task> Tasks()
        {
            var tasks = new List<Task>
            {
                new Task
                {
                    Id = 1,
                    TaskName = "Task 1",
                    CategoryId = 1,
                    Completed = false,
                    Date = DateTime.Now
                },
                new Task
                {
                    Id = 2,
                    TaskName = "Task 2",
                    CategoryId = 2,
                    Completed = false,
                    Date = DateTime.Now
                },
                new Task
                {
                    Id = 3,
                    TaskName = "Task 3",
                    CategoryId = 3,
                    Completed = false,
                    Date = DateTime.Now
                },
                new Task
                {
                    Id = 4,
                    TaskName = "Task 4",
                    CategoryId = 4,
                    Completed = false,
                    Date = DateTime.Now
                },
                new Task
                {
                    Id = 5,
                    TaskName = "Task 5",
                    CategoryId = 5,
                    Completed = false,
                    Date = DateTime.Now
                },
            };
            return tasks;
        }

        private static List<SubTask> SubTasks()
        {
            var subTasks = new List<SubTask>
            {
                new SubTask
                {
                    Id = 1,
                    Text = "Sub task 1",
                    TaskId = 1
                },
                new SubTask
                {
                    Id = 2,
                    Text = "Sub task 2",
                    TaskId = 2
                },
                new SubTask
                {
                    Id = 3,
                    Text = "Sub task 3",
                    TaskId = 3
                },
                new SubTask
                {
                    Id = 4,
                    Text = "Sub task 4",
                    TaskId = 4
                },
                new SubTask
                {
                    Id = 5,
                    Text = "Sub task 5",
                    TaskId = 5
                },
            };
            return subTasks;
        }
    }
}