using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSizes;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductSizeService:IEntityService<ProductSize,ProductSizesDto>
    {
        List<ProductSizeListDto> GetList(Guid productId);
    }
}