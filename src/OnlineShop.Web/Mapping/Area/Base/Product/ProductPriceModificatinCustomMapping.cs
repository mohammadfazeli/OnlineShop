using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductSalePrice;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductSalePriceCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductSalePrice,ProductSalePriceDto>()
                .ReverseMap();

            profile.CreateMap<ProductSalePrice,ProductSalePriceListDto>()
                .ForMember(d => d.FromDate,d => d.MapFrom(s => s.FromDate.ToString("yyyy/MM/dd")))
                .ForMember(d => d.NewPrice,opt => opt.MapFrom(x => x.NewPrice.ToCurrency().ToPersianNumbers()))
                .ForMember(d => d.OldPrice,opt => opt.MapFrom(x => x.OldPrice.ToCurrency().ToPersianNumbers()))
                .ReverseMap();
        }
    }
}