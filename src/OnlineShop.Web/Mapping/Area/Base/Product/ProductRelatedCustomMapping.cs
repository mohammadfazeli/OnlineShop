using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductRelated;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductRelatedCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductRelated,ProductRelatedDto>()
                .ReverseMap();

            profile.CreateMap<ProductRelated,ProductRelatedListDto>()
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.RelatedProductName,opt => opt.MapFrom(s => s.RelatedProduct.Name))
              .ReverseMap();
        }
    }
}