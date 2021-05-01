using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        private readonly ICategoryGroupService _categoryGroupService;
        private readonly IMemoryCache _cache;

        public CategoryViewComponent(ICategoryGroupService categoryGroupService,IMemoryCache cacheHelper)
        {
            _categoryGroupService = categoryGroupService;
            _cache = cacheHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryGeneralDto> cacheEntry = await _cache.GetOrCreateAsync(
                "_Category",
                entry =>
                {
                    entry.SetSize(1000);
                    return Task.FromResult(_categoryGroupService.GetCategoryGeneral());
                });

            return View(cacheEntry);
        }
    }
}