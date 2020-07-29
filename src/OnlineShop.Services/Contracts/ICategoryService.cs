using System.Collections.Generic;
using OnlineShop.Entities;

namespace OnlineShop.Services.Contracts
{
    public interface ICategoryService
    {
        void AddNewCategory(Category category);
        IList<Category> GetAllCategories();
    }
}