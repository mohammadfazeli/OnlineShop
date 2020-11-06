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

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductService : EntityService<Product, ProdcutDto>, IProductService
    {
        private readonly IAttachmentService _attachmentService;
        private DbSet<ProductDetail> _productDetails { set; get; }
        private DbSet<ProductPriceModificatin> _productPriceModificatins { set; get; }
        private DbSet<ProductGroup> _productGroups { set; get; }
        private DbSet<Model> _models { set; get; }
        private DbSet<Color> _colors { set; get; }
        private DbSet<Provider> _providers { set; get; }

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Product> repository
            , IAttachmentService attachmentService
            ) : base(unitOfWork, mapper, repository)
        {
            this._attachmentService = attachmentService;
            _productDetails = unitOfWork.Set<ProductDetail>();
            _productPriceModificatins = unitOfWork.Set<ProductPriceModificatin>();
            _productGroups = unitOfWork.Set<ProductGroup>();
            _models = unitOfWork.Set<Model>();
            _colors = unitOfWork.Set<Color>();
            _providers = unitOfWork.Set<Provider>();
        }

        public IQueryable<ProdcutListDto> GetList()
        {
            return GetAllNoTracking()
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
        }

        public ProdcutListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ProdcutListDto());
        }

        public IQueryable<ProdcutListDto> GetLastProduct(int take = 7)
        {
            return GetAllNoTracking().Where(x => !x.InActive).OrderByDescending(x => x.CreateOn).Take(take)
                .ProjectTo<ProdcutListDto>(_mapper.ConfigurationProvider);
        }

        public IQueryable<ProdcutListFullInfoDto> SearchProduct(ProductSearch productSearch)
        {
            if (string.IsNullOrEmpty(productSearch.Name) && productSearch.ModelId == null && string.IsNullOrEmpty(productSearch.UserCode))
                return new List<ProdcutListFullInfoDto>().AsQueryable();

            var result = (from p in GetAllNoTracking()
                          join pg in _productGroups.AsNoTracking() on p.ProductGroupId equals pg.Id
                          join pd in _productDetails.AsNoTracking() on p.Id equals pd.ProductId
                          join c in _colors.AsNoTracking() on pd.ColorId equals c.Id
                          join m in _models.AsNoTracking() on pd.ModelId equals m.Id
                          join pr in _providers.AsNoTracking() on pd.ProviderId equals pr.Id
                          join pdp in _productPriceModificatins.AsNoTracking() on pd.Id equals pdp.ProductDetailId
                          where !pd.IsDeleted && !pdp.IsDeleted && !pd.InActive && !pdp.InActive &&
                          DateTime.Now >= pdp.FromDate &&
                          (string.IsNullOrEmpty(productSearch.Name) || p.Name.Contains(productSearch.Name)) &&
                          (productSearch.ModelId == null || m.Id == productSearch.ModelId) &&
                          (string.IsNullOrEmpty(productSearch.UserCode) || p.UserCode.Contains(productSearch.UserCode))
                          select new ProdcutListFullInfoDto()
                          {
                              Id = pd.Id,
                              Name = p.Name,
                              ProductGroupName = pg.Name,
                              UserCode = p.UserCode,
                              ColorName = c.Name,
                              ProviderName = pr.Name,
                              ModelName = m.Name,
                              PricePrice = pdp.NewPrice
                          });
            return result;
        }
    }
}