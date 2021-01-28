using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSizes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductSizeService:EntityService<ProductSize,ProductSizesDto>, IProductSizeService
    {
        public ProductSizeService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ProductSize> repository) : base(unitOfWork,mapper,repository)
        {
        }

        public List<ProductSizeListDto> GetList(Guid productId)
        {
            var list = GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn)
             .ProjectTo<ProductSizeListDto>(_mapper.ConfigurationProvider).ToList();
            return list;
        }
    }
}