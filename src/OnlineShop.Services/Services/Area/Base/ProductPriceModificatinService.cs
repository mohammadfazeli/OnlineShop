using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSalePrice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductSalePriceService:EntityService<ProductSalePrice,ProductSalePriceDto>, IProductSalePriceService
    {
        public ProductSalePriceService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ProductSalePrice> repository)
            : base(unitOfWork,mapper,repository)
        {
        }

        public List<ProductSalePriceListDto> GetList(Guid productId)
        {
            var list = GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn).ToList();
            return _mapper.Map(list,new List<ProductSalePriceListDto>());
        }

        public ProductSalePriceListDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ProductSalePriceListDto());
        }
    }
}