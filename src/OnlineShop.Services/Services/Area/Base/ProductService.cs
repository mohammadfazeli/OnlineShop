using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.Utilities;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public IQueryable<ProdcutItemDto> GetShopItems(ShopDto search)
        {
            var minPrice = Convert.ToDecimal(search.MinPrice,new CultureInfo("en-US"));
            var maxPrice = Convert.ToDecimal(search.MaxPrice,new CultureInfo("en-US"));

            var items = (from p in GetAllNoTracking()
                         join pc in _productColors.AsNoTracking() on p.Id equals pc.ProductId into result_pc
                         from pc in result_pc.DefaultIfEmpty()
                         join ps in _productSizes.AsNoTracking() on p.Id equals ps.ProductId into result_ps
                         from ps in result_ps.DefaultIfEmpty()
                         where
                         (search.ProductGroupCheckBoxList == null || search.ProductGroupCheckBoxList.SelectedIds == null || search.ProductGroupCheckBoxList.SelectedIds.Contains(pc.ProductId.Value)) &&
                          (search.ColorCheckBoxList == null || search.ColorCheckBoxList.SelectedIds == null || search.ColorCheckBoxList.SelectedIds.Contains(pc.ColorId.Value)) &&
                          (search.ModelCheckBoxList == null || search.ModelCheckBoxList.SelectedIds == null || search.ModelCheckBoxList.SelectedIds.Contains(p.ModelId.Value)) &&
                          (search.SizeCheckBoxList == null || search.SizeCheckBoxList.SelectedIds == null || search.SizeCheckBoxList.SelectedIds.Contains(ps.SizeId.Value))
                         select p
                        )
            .ProjectTo<ProdcutItemDto>(_mapper.ConfigurationProvider)
            .Where(row => search.IsFilterPrice ? minPrice <= row.Price && row.Price <= maxPrice : true);
            return items;
        }

        public IQueryable<ProdcutListDto> GetLastProduct(int take = 7)
        {
            return GetAllNoTracking().Where(x => !x.InActive).OrderByDescending(x => x.CreateOn).Take(take)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
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