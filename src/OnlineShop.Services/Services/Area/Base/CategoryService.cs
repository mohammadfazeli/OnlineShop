using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.categories.Category;

namespace OnlineShop.Services.Services.Area.Base
{
    public class CategoryService:EntityService<Category,CategoryDto>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Category> repository) : base(unitOfWork,mapper,repository)
        {
        }
    }
}