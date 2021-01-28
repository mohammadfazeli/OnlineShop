using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductTagService:EntityService<ProductTags,ProductTagsDto>, IProductTagService
    {
        public ProductTagService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ProductTags> repository) : base(unitOfWork,mapper,repository)
        {
        }

        public List<ProductTagListDto> GetList(Guid productId)
        {
            var list = GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn)
             .ProjectTo<ProductTagListDto>(_mapper.ConfigurationProvider).ToList();
            return list;
        }
    }
}