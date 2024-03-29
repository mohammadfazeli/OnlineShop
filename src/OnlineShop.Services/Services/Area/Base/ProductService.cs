﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Utilities;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using OnlineShop.ViewModels.Area.Base.Sizes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductService:EntityService<Product,ProdcutDto>, IProductService
    {
        private DbSet<ProductGroup> _productGroups { set; get; }

        private DbSet<ProductSalePrice> _productSalePrices { set; get; }

        private DbSet<Model> _models { set; get; }
        private DbSet<ProductColor> _productColors { set; get; }
        private DbSet<ProductSize> _productSizes { set; get; }
        private DbSet<Provider> _providers { set; get; }

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Product> repository
            ,IAttachmentService attachmentService
            ) : base(unitOfWork,mapper,repository)
        {
            _productSalePrices = unitOfWork.Set<ProductSalePrice>();
            _productGroups = unitOfWork.Set<ProductGroup>();
            _models = unitOfWork.Set<Model>();
            _providers = unitOfWork.Set<Provider>();
            _productColors = unitOfWork.Set<ProductColor>();
            _productSizes = unitOfWork.Set<ProductSize>();
        }

        public IQueryable<ProdcutListDto> GetList()
        {
            return GetAllNoTracking()
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
        }

        public ProdcutGeneralInfoDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ProdcutGeneralInfoDto());
        }

        public DisplayProdcutDto GetDisplayProduct(Guid id)
        {
            var product = Get(id);
            var items = new DisplayProdcutDto()
            {
                Product = _mapper.Map(product,new ProdcutGeneralInfoDto()),
                RelatedProducts = _mapper.Map(product.RelatedProducts.Select(s => s.RelatedProduct),new List<ProdcutGeneralInfoDto>()),
            };

            return items;
        }

        public IQueryable<ProdcutGeneralInfoDto> GetShopItems(ShopDto search)
        {
            var minPrice = Convert.ToDecimal(search.MinPrice,new CultureInfo("en-US"));
            var maxPrice = Convert.ToDecimal(search.MaxPrice,new CultureInfo("en-US"));

            var x = CastToProductGeneralInfoList(from p in GetAllNoTracking()
                                                 join pc in _productColors.AsNoTracking() on p.Id equals pc.ProductId into result_pc
                                                 from pc in result_pc.DefaultIfEmpty()
                                                 join ps in _productSizes.AsNoTracking() on p.Id equals ps.ProductId into result_ps
                                                 from ps in result_ps.DefaultIfEmpty()
                                                 where
                                                 (search.CategoryGroupId == null || p.Category.CategoryGroupId == search.CategoryGroupId) &&
                                                 (search.CategoryId == null || p.CategoryId == search.CategoryId) &&
                                                 (string.IsNullOrEmpty(search.CategoryName) || p.Category.Name == search.CategoryName) &&
                                                 (string.IsNullOrEmpty(search.CategoryGroupName) || p.Category.CategoryGroup.Name == search.CategoryName) &&
                                                 (search.ProductGroupCheckBoxList == null || search.ProductGroupCheckBoxList.SelectedIds == null || search.ProductGroupCheckBoxList.SelectedIds.Contains(pc.ProductId.Value)) &&
                                                  (search.ColorCheckBoxList == null || search.ColorCheckBoxList.SelectedIds == null || search.ColorCheckBoxList.SelectedIds.Contains(pc.ColorId.Value)) &&
                                                  (search.ModelCheckBoxList == null || search.ModelCheckBoxList.SelectedIds == null || search.ModelCheckBoxList.SelectedIds.Contains(p.ModelId.Value)) &&
                                                  (search.SizeCheckBoxList == null || search.SizeCheckBoxList.SelectedIds == null || search.SizeCheckBoxList.SelectedIds.Contains(ps.SizeId.Value))
                                                 select p)
            .Where(row => !search.IsFilterPrice || (minPrice <= row.Price && row.Price <= maxPrice));
            //var items = x.ProjectTo<ProdcutGeneralInfoDto>(_mapper.ConfigurationProvider);
            return x;
        }

        public IQueryable<ProdcutListDto> GetLastProduct(int take = 7)
        {
            return GetAllNoTracking().Where(x => !x.InActive).OrderByDescending(x => x.CreateOn).Take(take)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
        }

        public async Task<ProdcutGeneralInfoDto> GetProdcut(Guid Id)
        {
            var product = (await GetAsync(Id));
            return CastToProductGeneralInfo(product);
        }

        public IQueryable<ProdcutGeneralInfoDto> CastToProductGeneralInfoList(IQueryable<Product> products)
        {
            return products.Select(product => new ProdcutGeneralInfoDto()
            {
                Id = product.Id,
                ProductName = product.Name,
                CreateOn = product.CreateOn,
                ProductGroupName = product.ProductGroup.Name ?? "",
                UserCode = product.UserCode ?? "",
                ForeignName = product.ForeignName ?? "",
                Description = product.Description ?? "",
                Provider = product.Provider == null ? "" : product.Provider.Name,
                CategoryName = product.Category == null ? "" : product.Category.Name,
                OldPrice = !product.ProductSalePrices.Any(p => !p.IsDeleted && !p.InActive) ? (decimal)0 : ((decimal)(product.ProductSalePrices.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault().OldPrice)),
                Price = !product.ProductSalePrices.Any(p => !p.IsDeleted && !p.InActive) ? (decimal)0 : (decimal)(product.ProductSalePrices.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault().NewPrice),
                ModelName = product.Model.Name ?? "",
                ProductColors = (product.ProductColors.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ColorstDto
                {
                    Id = c.ColorId.Value,
                    UserCode = c.Color.UserCode,
                    Name = c.Color.Name
                }).ToList()),
                ProductSizes = (product.ProductSizes.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new SizeDto
                {
                    Id = c.SizeId.Value,
                    Name = c.Size.Name
                }).ToList()),
                ProductTags = (product.ProductTags.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ProductTagListDto
                {
                    Id = c.Id,
                    TagName = c.Name
                }).ToList()),
                ProductSpecifications = (product.ProductSpecifications.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ProductSpecificationListDto
                {
                    SpecificationName = c.SpecificationName,
                    SpecificationValue = c.SpecificationValue
                }).ToList())
            });
        }

        public ProdcutGeneralInfoDto CastToProductGeneralInfo(Product product)
        {
            return new ProdcutGeneralInfoDto()
            {
                Id = product.Id,
                ProductName = product.Name,
                ProductGroupName = product?.ProductGroup?.Name ?? "",
                UserCode = product?.UserCode ?? "",
                ForeignName = product?.ForeignName ?? "",
                Description = product?.Description ?? "",
                Provider = product?.Provider == null ? "" : product?.Provider?.Name,
                OldPrice = ((decimal)(product?.ProductSalePrices?.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault()?.OldPrice ?? 0)),
                Price = (decimal)(product?.ProductSalePrices?.Where(p => !p.IsDeleted && !p.InActive).OrderByDescending(x => x.CreateOn).FirstOrDefault()?.NewPrice ?? 0),
                ModelName = product?.Model?.Name ?? "",
                ProductColors = (product?.ProductColors?.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ColorstDto
                {
                    Id = c.ColorId.Value,
                    UserCode = c.Color.UserCode,
                    Name = c.Color.Name
                }).ToList()),
                ProductSizes = (product?.ProductSizes?.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new SizeDto
                {
                    Id = c.SizeId.Value,
                    Name = c.Size.Name
                }).ToList()),
                ProductTags = (product?.ProductTags?.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ProductTagListDto
                {
                    Id = c.Id,
                    TagName = c.Name
                }).ToList()),
                ProductSpecifications = (product?.ProductSpecifications?.Where(p => !p.IsDeleted && !p.InActive)
                .Select(c => new ProductSpecificationListDto
                {
                    SpecificationName = c.SpecificationName,
                    SpecificationValue = c.SpecificationValue
                }).OrderBy(o => o.SortOrder).ToList())
            };
        }

        public IQueryable<ProdcutListFullInfoDto> SearchProduct(ProductSearch productSearch)
        {
            if(string.IsNullOrEmpty(productSearch.Name) && productSearch.ModelId == null && string.IsNullOrEmpty(productSearch.UserCode))
                return new List<ProdcutListFullInfoDto>().AsQueryable();

            var result = (from p in GetAllNoTracking()
                          join m in _models.AsNoTracking() on p.ModelId equals m.Id into model_result
                          from m in model_result.DefaultIfEmpty()

                          join pg in _productGroups.AsNoTracking() on p.ProductGroupId equals pg.Id into productGroup_result
                          from pg in productGroup_result.DefaultIfEmpty()

                          join pr in _providers.AsNoTracking() on p.ProviderId equals pr.Id into provider_result
                          from pr in provider_result.DefaultIfEmpty()

                          where !p.IsDeleted && !p.InActive &&
                          (string.IsNullOrEmpty(productSearch.Name) || p.Name.Contains(productSearch.Name)) &&
                          (productSearch.ModelId == null || m.Id == productSearch.ModelId) &&
                          (string.IsNullOrEmpty(productSearch.UserCode) || p.UserCode.Contains(productSearch.UserCode))

                          let product = _productSalePrices.AsNoTracking()
                                .Where(row => row.ProductId == p.Id && !row.IsDeleted && !row.InActive)
                                .OrderByDescending(o => o.CreateOn)
                                .FirstOrDefault()

                          select new ProdcutListFullInfoDto()
                          {
                              Id = p.Id,
                              Name = p.Name,
                              UserCode = p.UserCode,
                              ProductGroupName = pg != null ? pg.Name : "",
                              ProviderName = pr == null ? "" : pr.Name,
                              ModelName = m == null ? "" : m.Name,
                              Price = product.NewPrice.ToCurrency(),
                              OldPrice = product.OldPrice.ToCurrency()
                          });

            return result;
        }

        public ProductSalePrice GetLastPrice(Guid productId)
        {
            var item = _productSalePrices.AsNoTracking()
                .Where(p => p.ProductId == productId && !p.IsDeleted && !p.InActive)
                .OrderByDescending(o => o != null ? o.CreateOn : new DateTime())
                .FirstOrDefault();
            return item;
        }
    }
}