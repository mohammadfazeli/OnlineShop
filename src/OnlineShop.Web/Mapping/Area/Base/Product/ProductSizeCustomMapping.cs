using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductSizes;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductSizeCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductSize,ProductSizesDto>()
                .ReverseMap();

            profile.CreateMap<ProductSize,ProductSizeListDto>()
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.SizeName,opt => opt.MapFrom(s => s.Size.Name))
              .ReverseMap();
        }
    }
}