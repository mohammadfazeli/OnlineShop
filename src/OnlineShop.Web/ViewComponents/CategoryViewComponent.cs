using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly ICategoryGroupService _categoryGroupService;

        public CategoryViewComponent(ICategoryGroupService categoryGroupService)
        {
            _categoryGroupService = categoryGroupService;
        }

        public IViewComponentResult Invoke()
        {
            var categoryGenerals = _categoryGroupService.GetCategoryGeneral();
            return View(categoryGenerals);
        }
    }
}