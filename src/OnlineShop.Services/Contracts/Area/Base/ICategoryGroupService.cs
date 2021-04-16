using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.categories;
using OnlineShop.ViewModels.Area.Base.categories.CategoryGroup;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface ICategoryGroupService:IEntityService<CategoryGroup,CategoryGroupDto>
    {
        List<CategoryGeneralDto> GetCategoryGeneral();
    }
}