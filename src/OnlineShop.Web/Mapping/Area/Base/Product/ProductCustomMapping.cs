using AutoMapper;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using OnlineShop.ViewModels.Area.Base.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Mapping.Area.Base
{
    public class ProductCustomMapping:IHaveCustomMapping
    {
        public void CreateMappings(Profile profile)
        {
            profile.CreateMap<Product,ProdcutDto>()
                .ReverseMap();

            profile.CreateMap<Product,ProdcutListDto>()
                .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.ProductGroup.Name))
                .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Model.Name))
                .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Provider.Name))
                .ReverseMap();

            profile.CreateMap<Product,ProdcutGeneralInfoDto>()
              .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Name == null ? "" : s.Name))
              .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.ProductGroup == null ? "" : s.ProductGroup.Name ?? ""))
              .ForMember(d => d.Description,opt => opt.MapFrom(s => s.Description == null ? "" : s.Description))
              .ForMember(d => d.ForeignName,opt => opt.MapFrom(s => s.ForeignName == null ? "" : s.ForeignName))
              .ForMember(d => d.UserCode,opt => opt.MapFrom(s => s.UserCode == null ? "" : s.UserCode))
              .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Model == null ? "" : s.Model.Name ?? ""))
              .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Provider == null ? "" : s.Provider.Name ?? ""))
              .ForMember(d => d.CategoryName,opt => opt.MapFrom(s => s.Category == null ? "" : s.Category.Name ?? ""))
              .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.ProductSalePrices.Count == 0 ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).OldPrice))
              .ForMember(d => d.Price,opt => opt.MapFrom(s => s.ProductSalePrices.Count == 0 ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).NewPrice))
              .ForMember(d => d.ProductColors,opt => opt.MapFrom(s => s.ProductColors.Count == 0 /*|| !s.ProductColors.Any(p => !p.IsDeleted && !p.InActive)*/ ? new List<ColorstDto>() :
            s.ProductColors.Where(p => !p.IsDeleted && !p.InActive)
            .Select(c => new ColorstDto
            {
                Id = c.ColorId.Value,
                UserCode = c.Color.UserCode ?? "",
                Name = c.Color.Name ?? ""
            })))
            .ForMember(d => d.ProductSizes,opt => opt.MapFrom(s => s.ProductSizes.Count == 0/* || !s.ProductSizes.Any(p => !p.IsDeleted && !p.InActive) */? new List<SizeDto>() :
            s.ProductSizes.Where(p => !p.IsDeleted && !p.InActive)
            .Select(c => new SizeDto
            {
                Id = c.SizeId ?? new Guid(),
                Name = c.Size.Name ?? ""
            })))
            .ForMember(d => d.ProductTags,opt => opt.MapFrom(s => s.ProductTags.Count == 0 /*|| !s.ProductTags.Any(p => !p.IsDeleted && !p.InActive)*/ ? new List<ProductTagListDto>()
            : s.ProductTags.Where(p => !p.IsDeleted && !p.InActive)
            .Select(c => new ProductTagListDto
            {
                Id = c.Id,
                TagName = c.Name ?? ""
            })))
            .ForMember(d => d.ProductSpecifications,opt => opt.MapFrom(s => s.ProductSpecifications.Count == 0/* || !s.ProductSpecifications.Any(p => !p.IsDeleted && !p.InActive)*/ ? new List<ProductSpecificationListDto>()
            : s.ProductSpecifications.Where(p => !p.IsDeleted && !p.InActive)
            .Select(c => new ProductSpecificationListDto
            {
                SpecificationName = c.SpecificationName ?? "",
                SpecificationValue = c.SpecificationValue ?? "",
                SortOrder = c.SortOrder
            })))
            .ReverseMap();

            profile.CreateMap<Product,ProdcutItemDto>()
             .ForMember(d => d.ProductId,opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.ProductUserCode,opt => opt.MapFrom(s => s.UserCode))
              .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.ProductGroup.Name))
              .ForMember(d => d.ForeignName,opt => opt.MapFrom(s => s.ForeignName))
              .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Model.Name))
              .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Provider.Name))
              .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).OldPrice))
              .ForMember(d => d.Price,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).FirstOrDefault(price => !price.IsDeleted && !price.InActive).NewPrice))
              .ReverseMap();
        }
    }
}