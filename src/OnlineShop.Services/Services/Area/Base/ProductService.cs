using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

using OnlineShop.Common.Utilities;

using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductService:EntityService<Product,ProdcutDto>, IProductService
    {
        private readonly IAttachmentService _attachmentService;

        private DbSet<ProductSalePrice> _productPriceModificatins { set; get; }
        private DbSet<ProductGroup> _productGroups { set; get; }
        private DbSet<ProductSize> _productSizes { set; get; }

        private DbSet<ProductSalePrice> _productSalePrices { set; get; }

        private DbSet<Model> _models { set; get; }
        private DbSet<Color> _colors { set; get; }
        private DbSet<Provider> _providers { set; get; }

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Product> repository
            ,IAttachmentService attachmentService
            ) : base(unitOfWork,mapper,repository)
        {
            this._attachmentService = attachmentService;

            _productPriceModificatins = unitOfWork.Set<ProductSalePrice>();

            _productSalePrices = unitOfWork.Set<ProductSalePrice>();
            _productGroups = unitOfWork.Set<ProductGroup>();
            _models = unitOfWork.Set<Model>();
            _colors = unitOfWork.Set<Color>();
            _providers = unitOfWork.Set<Provider>();

            _productSizes = unitOfWork.Set<ProductSize>();
        }

        public IQueryable<ProdcutListDto> GetList()
        {
            return GetAllNoTracking()
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
        }

        public ProdcutListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ProdcutListDto());
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