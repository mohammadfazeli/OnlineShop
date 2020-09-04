using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductPriceModificatin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductPriceModificatinService : EntityService<ProductPriceModificatin, ProductPriceModificatinDto>, IProductPriceModificatinService
    {
        public ProductPriceModificatinService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ProductPriceModificatin> repository)
            : base(unitOfWork, mapper, repository)
        {
        }

        public List<ProductPriceModificatinListDto> GetList(Guid productDetailId)
        {
            var list = GetAll()
                .Where(x => x.ProductDetailId == productDetailId)
                .OrderByDescending(x => x.CreateOn).ToList();
            return _mapper.Map(list, new List<ProductPriceModificatinListDto>());
        }

        public ProductPriceModificatinListDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ProductPriceModificatinListDto());
        }
    }
}