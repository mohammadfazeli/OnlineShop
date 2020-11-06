using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductPriceModificatin;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductPriceModificatinCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductPriceModificatin, ProductPriceModificatinDto>()
                .ReverseMap();

            profile.CreateMap<ProductPriceModificatin, ProductPriceModificatinListDto>()
                .ForMember(d => d.strFromDate, d => d.MapFrom(s => s.FromDate.ToString("yyyy/MM/dd").ToPersianNumbers()))
                .ForMember(d => d.NewPrice, opt => opt.MapFrom(x => x.NewPrice.ToNumeric().ToPersianNumbers()))
                .ForMember(d => d.OldPrice, opt => opt.MapFrom(x => x.OldPrice.ToNumeric().ToPersianNumbers()))
                .ReverseMap();
        }
    }
}