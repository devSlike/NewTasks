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
    public class SubTaskService
    {
        private readonly SubTaskRepository _repository;
        private readonly TaskRepository _taskRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SubTaskService()
        {
            _repository = new SubTaskRepository(new TasksContext() as DbContext);
            _taskRepository = new TaskRepository(new TasksContext() as DbContext);
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<SubTask> GetSubTasks(Int32 taskId)
        {
            return _repository.All().Where(x => x.TaskId == taskId);
        }

        public SubTask GetSubTask(Int32 Id)
        {
            return _repository.Get(x => x.Id == Id);
        }

        public void AddSubTask(SubTask subTask)
        {
            _repository.Add(subTask);
            _repository.SaveChanges();
        }

        public void DeleteSubTask(Int32 Id)
        {
            var item = _repository.Get(x => x.Id == Id);
            if (item == null) return;
            _repository.Delete(item);
            _repository.SaveChanges();
        }

        public void UpdateSubTask(SubTask subTask)
        {
            _repository.Update(subTask);
            var task = _taskRepository.All().FirstOrDefault(x => x.Id == subTask.TaskId);
            var allSubTasks = _repository.All().Where(x => x.TaskId == subTask.TaskId);
            if (allSubTasks.Count() == allSubTasks.Where(x => x.Completed).Count())
            {
                if (task != null)
                    task.Completed = true;
            }
            else
                if (task != null)
                    if (task.Completed)
                        task.Completed = false;
            _taskRepository.SaveChanges();
            _repository.SaveChanges();
        }
    }
}
