using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Products;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Product, ProdcutDto>()
                .ReverseMap();

            profile.CreateMap<Product, ProdcutListDto>()
                .ForMember(d => d.ProductGroupName, opt => opt.MapFrom(s => s.ProductGroup.Name))
                .ReverseMap();
        }
    }
}