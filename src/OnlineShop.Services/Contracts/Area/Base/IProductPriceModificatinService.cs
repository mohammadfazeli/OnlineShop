using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductPriceModificatin;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductPriceModificatinService : IEntityService<ProductPriceModificatin, ProductPriceModificatinDto>
    {
        List<ProductPriceModificatinListDto> GetList(Guid productDetailId);

        ProductPriceModificatinListDto GetInfo(Guid id);
    }
}