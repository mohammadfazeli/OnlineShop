using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.Products;
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
                .ForMember(d => d.SectionName,opt => opt.MapFrom(s => s.Section.Name))
                .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Product.Model.Name))
                .ForMember(d => d.CurrentPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices == null ? "" : s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).NewPrice.ToCurrency().ToPersianNumbers()))
                .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices == null ? "" : s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).OldPrice.ToCurrency().ToPersianNumbers()))
                 .ReverseMap();

            profile.CreateMap<ItemSection,ProdcutItemDto>()
             .ForMember(d => d.ProductId,opt => opt.MapFrom(s => s.ProductId))
             .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Product.Name))
             .ForMember(d => d.ProductUserCode,opt => opt.MapFrom(s => s.Product.UserCode))
             .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.Product.ProductGroup.Name))
             .ForMember(d => d.ForeignName,opt => opt.MapFrom(s => s.Product.ForeignName))
             .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Product.Model.Name))
             .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Product.Provider.Name))
             .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.Product.ProductSalePrices == null ? 0 : s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).Where(price => !price.IsDeleted && !price.InActive).FirstOrDefault().OldPrice))
             .ForMember(d => d.Price,opt => opt.MapFrom(s => s.Product.ProductSalePrices == null ? 0 : s.Product.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).Where(price => !price.IsDeleted && !price.InActive).FirstOrDefault().NewPrice))
             .ReverseMap();
        }
    }
}