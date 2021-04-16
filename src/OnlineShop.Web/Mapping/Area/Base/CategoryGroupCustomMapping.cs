using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.categories.CategoryGroup;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class CategoryGroupCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<CategoryGroup,CategoryGroupDto>()
                .ReverseMap();

            profile.CreateMap<CategoryGroup,CategoryGroupListDto>()
               .ReverseMap();
        }
    }
}