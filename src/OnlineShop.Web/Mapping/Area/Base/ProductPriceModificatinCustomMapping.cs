using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ProductPriceModificatin;
using System;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductPriceModificatinCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ProductPriceModificatin, ProductPriceModificatinDto>()
                .ReverseMap();

            profile.CreateMap<ProductPriceModificatin, ProductPriceModificatinListDto>()
                .ForMember(d => d.strFromDate, d => d.MapFrom(s => s.FromDate.ToString("yyyy/MM/dd")))
                .ReverseMap();
        }
    }
}