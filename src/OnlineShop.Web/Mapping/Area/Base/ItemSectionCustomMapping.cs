using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using System.Linq;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ItemSectionCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ItemSection,ItemSectionDto>()
                .ReverseMap();

            profile.CreateMap<ItemSection,ItemSectionListDto>()
                .ForMember(d => d.strFromDate,opt => opt.MapFrom(s => s.FromDate == null ? "" : s.FromDate.ToPersianDate().ToPersianNumbers()))
                .ForMember(d => d.StrToDate,opt => opt.MapFrom(s => s.ToDate == null ? "" : s.ToDate.ToPersianDate().ToPersianNumbers()))
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Product.Model.Name))
                .ForMember(d => d.CurrentPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).NewPrice.ToCurrency().ToPersianNumbers()))
                .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).OldPrice.ToCurrency().ToPersianNumbers()))
                 .ReverseMap();
        }
    }
}