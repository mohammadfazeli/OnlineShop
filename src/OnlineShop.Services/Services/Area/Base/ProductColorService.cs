using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductColors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductColorService:EntityService<ProductColor,ProductColorsDto>, IProductColorService
    {
        public ProductColorService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ProductColor> repository) : base(unitOfWork,mapper,repository)
        {
        }

        //public List<ProductColorsListDto> GetList(Guid productId)
        //{
        //    var list = GetAllNoTracking()
        //        .Where(x => x.ProductId == productId)
        //        .OrderByDescending(x => x.CreateOn)
        //     .ProjectTo<ProductColorsListDto>(_mapper.ConfigurationProvider).ToList();
        //    return list;
        //}
    }
}