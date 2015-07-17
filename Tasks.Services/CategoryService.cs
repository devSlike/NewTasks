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
    public class CategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWorkFactory factory)
        {
            _unitOfWork = factory.Create();
           _repository = _unitOfWork.Repository<Category>();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repository.All();
        }

        public Category GetCategory(Int32 Id)
        {
            return _repository.Get(x => x.Id == Id);
        }

        public void AddCategory(Category category)
        {
            _repository.Add(category);
            _repository.SaveChanges();
        }

        public void DeleteCategory(Int32 Id)
        {
            var item = _repository.Get(x => x.Id == Id);
            if (item == null) return;
            _repository.Delete(item);
            _repository.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
            _repository.SaveChanges();
        }
    }
}