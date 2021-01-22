using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ItemSections;
<<<<<<< HEAD
=======
using System;
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
using System.Linq;

namespace OnlineShop.Web.Mapping.Area.Base
{
<<<<<<< HEAD
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
                .ForMember(d => d.CurrentPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).NewPrice.ToCurrency()))
                .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).OldPrice.ToCurrency()))
=======
    public class ItemSectionCustomMapping : IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<ItemSection, ItemSectionDto>()
                .ReverseMap();

            profile.CreateMap<ItemSection, ItemSectionListDto>()
                .ForMember(d => d.strFromDate, opt => opt.MapFrom(s => s.FromDate == null ? "" : s.FromDate.Value.ToString("yyyy/MM/dd").ToPersianNumbers()))
                .ForMember(d => d.StrToDate, opt => opt.MapFrom(s => s.ToDate == null ? "" : s.ToDate.Value.ToString("yyyy/MM/dd").ToPersianNumbers()))
                .ForMember(d => d.ProductName, opt => opt.MapFrom(s => s.ProductDetail.Product.Name))
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductDetail.ProductId))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.ProductDetail.ProductPriceModificatins.Where(p => !p.IsDeleted && !p.InActive && s.FromDate <= DateTime.Now).OrderByDescending(o => o.CreateOn).FirstOrDefault().NewPrice.ToNumeric().ToPersianNumbers()))
                .ForMember(d => d.OldPrice, opt => opt.MapFrom(s => s.ProductDetail.ProductPriceModificatins.Where(p => !p.IsDeleted && !p.InActive && s.FromDate <= DateTime.Now).OrderByDescending(o => o.CreateOn).FirstOrDefault().OldPrice.ToNumeric().ToPersianNumbers()))
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
                .ReverseMap();
        }
    }
}