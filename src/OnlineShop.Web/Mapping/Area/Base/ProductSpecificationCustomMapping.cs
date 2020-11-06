using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductSpecificationCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductSpecification, ProductSpecificationDto>()
                .ReverseMap();

            profile.CreateMap<ProductSpecification, ProductSpecificationListDto>()
                .ReverseMap();
        }
    }
}