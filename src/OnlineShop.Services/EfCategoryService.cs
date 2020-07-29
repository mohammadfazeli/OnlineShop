using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities;
using OnlineShop.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services
{
    public class EfCategoryService : ICategoryService
    {
        private IRepository<Category> _repository { get; }

        public EfCategoryService(IRepository<Category> repository)
        {
            _repository = repository;

        }

        public void AddNewCategory(Category category)
        {
            _repository.Create(category);
        }

        public IList<Category> GetAllCategories()
        {
            return _repository.GetAll().ToList();
        }
    }
}