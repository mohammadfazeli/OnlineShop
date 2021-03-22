using AutoMapper;
using DNTPersianUtils.Core;
using OnlineShop.Common.Utilities;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.IocConfig.CustomMapping;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using OnlineShop.ViewModels.Area.Base.Sizes;
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
              .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.ProductGroup.Name))
              .ForMember(d => d.UserCode,opt => opt.MapFrom(s => s.UserCode))
              .ForMember(d => d.ForeignName,opt => opt.MapFrom(s => s.ForeignName))
              .ForMember(d => d.Description,opt => opt.MapFrom(s => s.Description))
              .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Model.Name))
              .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Provider.Name))
              .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault().OldPrice))
              .ForMember(d => d.Price,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault().NewPrice))
              .ForMember(d => d.ProductColors,opt => opt.MapFrom(s => s.ProductColors == null ? null : s.ProductColors.Where(p => !p.IsDeleted && !p.InActive)
              .Select(c => new ColorstDto
              {
                  Id = c.ColorId.Value,
                  UserCode = c.Color.UserCode,
                  Name = c.Color.Name
              })))
              .ForMember(d => d.ProductSizes,opt => opt.MapFrom(s => s.ProductSizes == null ? null : s.ProductSizes.Where(p => !p.IsDeleted && !p.InActive)
              .Select(c => new SizeDto
              {
                  Id = c.SizeId.Value,
                  Name = c.Size.Name
              })))
              .ForMember(d => d.ProductTags,opt => opt.MapFrom(s => s.ProductTags == null ? null : s.ProductTags.Where(p => !p.IsDeleted && !p.InActive)
              .Select(c => new ProductTagListDto
              {
                  Id = c.Id,
                  TagName = c.Name
              })))
              .ForMember(d => d.ProductSpecifications,opt => opt.MapFrom(s => s.ProductSpecifications == null ? null : s.ProductSpecifications.Where(p => !p.IsDeleted && !p.InActive)
              .Select(c => new ProductSpecificationListDto
              {
                  SpecificationName = c.SpecificationName,
                  SpecificationValue = c.SpecificationValue
              }).OrderBy(o => o.SortOrder)))
              .ReverseMap();

            profile.CreateMap<Product,ProdcutItemDto>()
             .ForMember(d => d.ProductId,opt => opt.MapFrom(s => s.Id))
              .ForMember(d => d.ProductName,opt => opt.MapFrom(s => s.Name))
              .ForMember(d => d.ProductUserCode,opt => opt.MapFrom(s => s.UserCode))
              .ForMember(d => d.ProductGroupName,opt => opt.MapFrom(s => s.ProductGroup.Name))
              .ForMember(d => d.ForeignName,opt => opt.MapFrom(s => s.ForeignName))
              .ForMember(d => d.ModelName,opt => opt.MapFrom(s => s.Model.Name))
              .ForMember(d => d.Provider,opt => opt.MapFrom(s => s.Provider.Name))
              .ForMember(d => d.OldPrice,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).Where(price => !price.IsDeleted && !price.InActive).FirstOrDefault().OldPrice))
              .ForMember(d => d.Price,opt => opt.MapFrom(s => s.ProductSalePrices == null ? 0 : s.ProductSalePrices.OrderByDescending(pc => pc.CreateOn).Where(price => !price.IsDeleted && !price.InActive).FirstOrDefault().NewPrice))
              .ReverseMap();
        }
    }
}