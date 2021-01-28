using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductTag;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductTagCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductTags,ProductTagsDto>()
                .ReverseMap();

            profile.CreateMap<ProductTags,ProductTagListDto>()
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.TagName,opt => opt.MapFrom(s => s.Name))
              .ReverseMap();
        }
    }
}