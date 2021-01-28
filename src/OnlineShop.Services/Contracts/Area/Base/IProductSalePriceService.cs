using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSalePrice;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductSalePriceService:IEntityService<ProductSalePrice,ProductSalePriceDto>
    {
        List<ProductSalePriceListDto> GetList(Guid productId);

        ProductSalePriceListDto GetInfo(Guid id);

        ProductSalePrice GetLastPrice(Guid productId);
    }
}