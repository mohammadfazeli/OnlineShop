using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductDetails;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductDetailCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductDetail, ProductDetailDto>()
                .ReverseMap();

            profile.CreateMap<ProductDetail, ProductDetailListDto>()
                .ForMember(d => d.ModelName, opt => opt.MapFrom(s => s.Model.Name))
                .ForMember(d => d.ColorName, opt => opt.MapFrom(s => s.Color.Name))
                .ForMember(d => d.ProviderName, opt => opt.MapFrom(s => s.Provider.Name))
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.Product.Name))
                .ReverseMap();
        }
    }
}