using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductColors;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductColorService:IEntityService<ProductColor,ProductColorsDto>
    {
        List<ProductColorsListDto> GetList(Guid productId);
    }
}