using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.categories.Category;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class CategoryCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Category,CategoryDto>()
                .ReverseMap();

            profile.CreateMap<Category,CategoryListDto>()
                .ForMember(x => x.ParentCategoryName,dis => dis.MapFrom(r => r.ParentCategory.Name))
                .ForMember(x => x.CategoryGroupName,dis => dis.MapFrom(r => r.CategoryGroup.Name))
               .ReverseMap();
        }
    }
}