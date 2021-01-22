using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
<<<<<<< HEAD
=======
using OnlineShop.Common.Utilities;
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
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
    public class ProductService:EntityService<Product,ProdcutDto>, IProductService
    {
        private readonly IAttachmentService _attachmentService;
<<<<<<< HEAD
        private DbSet<ProductSalePrice> _productPriceModificatins { set; get; }
        private DbSet<ProductGroup> _productGroups { set; get; }
        private DbSet<ProductSize> _productSizes { set; get; }
=======
        private DbSet<ProductDetail> _productDetails { set; get; }
        private DbSet<ProductPriceModificatin> _productPriceModificatins { set; get; }
        private DbSet<ProductGroup> _productGroups { set; get; }
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        private DbSet<Model> _models { set; get; }
        private DbSet<Color> _colors { set; get; }
        private DbSet<Provider> _providers { set; get; }

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<Product> repository
            ,IAttachmentService attachmentService
            ) : base(unitOfWork,mapper,repository)
        {
            this._attachmentService = attachmentService;
<<<<<<< HEAD
            _productPriceModificatins = unitOfWork.Set<ProductSalePrice>();
=======
            _productDetails = unitOfWork.Set<ProductDetail>();
            _productPriceModificatins = unitOfWork.Set<ProductPriceModificatin>();
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
            _productGroups = unitOfWork.Set<ProductGroup>();
            _models = unitOfWork.Set<Model>();
            _colors = unitOfWork.Set<Color>();
            _providers = unitOfWork.Set<Provider>();
<<<<<<< HEAD
            _productSizes = unitOfWork.Set<ProductSize>();
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
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
<<<<<<< HEAD
            if(string.IsNullOrEmpty(productSearch.Name) && productSearch.ModelId == null && string.IsNullOrEmpty(productSearch.UserCode))
=======
            if (string.IsNullOrEmpty(productSearch.Name) && productSearch.ModelId == null && string.IsNullOrEmpty(productSearch.UserCode))
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
                return new List<ProdcutListFullInfoDto>().AsQueryable();

            var result = (from p in GetAllNoTracking()
                          join pg in _productGroups.AsNoTracking() on p.ProductGroupId equals pg.Id
<<<<<<< HEAD
                          join m in _models.AsNoTracking() on p.ModelId equals m.Id
                          join pr in _providers.AsNoTracking() on p.ProviderId equals pr.Id
                          join pdp in _productPriceModificatins.AsNoTracking() on p.Id equals pdp.ProductId
                          where !p.IsDeleted && !pdp.IsDeleted && !p.InActive && !pdp.InActive &&
=======
                          join pd in _productDetails.AsNoTracking() on p.Id equals pd.ProductId
                          join c in _colors.AsNoTracking() on pd.ColorId equals c.Id
                          join m in _models.AsNoTracking() on pd.ModelId equals m.Id
                          join pr in _providers.AsNoTracking() on pd.ProviderId equals pr.Id
                          join pdp in _productPriceModificatins.AsNoTracking() on pd.Id equals pdp.ProductDetailId
                          where !pd.IsDeleted && !pdp.IsDeleted && !pd.InActive && !pdp.InActive &&
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
                          DateTime.Now >= pdp.FromDate &&
                          (string.IsNullOrEmpty(productSearch.Name) || p.Name.Contains(productSearch.Name)) &&
                          (productSearch.ModelId == null || m.Id == productSearch.ModelId) &&
                          (string.IsNullOrEmpty(productSearch.UserCode) || p.UserCode.Contains(productSearch.UserCode))
                          select new ProdcutListFullInfoDto()
                          {
<<<<<<< HEAD
                              Id = p.Id,
                              Name = p.Name,
                              ProductGroupName = pg.Name,
                              UserCode = p.UserCode,
                              ProviderName = pr.Name,
                              ModelName = m.Name,
                              Price = pdp.NewPrice,
                              OldPrice = pdp.OldPrice,
                          });
            return result;
        }

        public decimal GetLastPrice(Guid productId)
        {
            return Get(productId)
                .ProductSalePrices.Where(p => !p.IsDeleted && !p.InActive && p.FromDate <= DateTime.Now)
                .OrderByDescending(o => o != null ? o.CreateOn : new DateTime())
                .FirstOrDefault()?
                .NewPrice ?? 0;
        }
=======
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
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
    }
}