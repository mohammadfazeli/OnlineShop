using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductGroups;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductGroupCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductGroup, ProductGroupDto>()
                .ReverseMap();
        }
    }
}