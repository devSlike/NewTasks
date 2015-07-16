using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tasks.DataAccess.Entities;
using Tasks.DataAccess.Infrastructure;
using Tasks.DataAccess.Repositories;

namespace Tasks.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public TaskService()
        {
            _repository = new TaskRepository(new TasksContext() as DbContext);
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Task> GetTasks()
        {
            return _repository.All();
        }

        public Task GetTask(Int32 Id)
        {
            return _repository.Get(x => x.Id == Id);
        }

        public void AddTask(Task task)
        {
            _repository.Add(task);
            _repository.SaveChanges();
        }

        public void DeleteTask(Int32 Id)
        {
            var item = _repository.Get(x => x.Id == Id);
            if (item == null) return;
            _repository.Delete(item);
            _repository.SaveChanges();
        }

        public void DeleteCompletedTasks()
        {
            var items = _repository.All().Where(x => x.Completed).ToList();
            items.ForEach(x => _repository.Delete(x));
            _repository.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _repository.Update(task);
            _repository.SaveChanges();
        }
    }
}
