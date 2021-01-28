using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductColors;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductColorCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductColor,ProductColorsDto>()
                .ReverseMap();

            profile.CreateMap<ProductColor,ProductColorsListDto>()
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ColorName,opt => opt.MapFrom(s => s.Color.Name))
              .ReverseMap();
        }
    }
}