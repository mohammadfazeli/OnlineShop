using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.ProductRelated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductRelatedService:EntityService<ProductRelated,ProductRelatedDto>, IProductRelatedService
    {
        public ProductRelatedService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ProductRelated> repository) : base(unitOfWork,mapper,repository)
        {
        }

        public List<ItemSectionListDto> GetRelatedItems(Guid productId)
        {
            var list = GetAllNoTracking()
                .Where(x => !x.InActive && x.ProductId == productId)
                .Select(x => new ItemSectionListDto()
                {
                    ProductId = x.RelatedProductId,
                    ProductName = x.RelatedProduct.Name,
                    CurrentPrice = x.RelatedProduct.ProductSalePrices.OrderByDescending(s => s.CreateOn).FirstOrDefault().NewPrice.ToString(),
                    OldPrice = x.RelatedProduct.ProductSalePrices.OrderByDescending(s => s.CreateOn).FirstOrDefault().OldPrice.ToString(),
                }
                );
            return list.ToList();
        }

        public List<ProductRelatedListDto> GetList(Guid productId)
        {
            var list = GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn)
             .ProjectTo<ProductRelatedListDto>(_mapper.ConfigurationProvider).ToList();
            return list;
        }
    }
}