using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.ProductRelated;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductRelatedService:IEntityService<ProductRelated,ProductRelatedDto>
    {
        List<ItemSectionListDto> GetRelatedItems(Guid productId);

        List<ProductRelatedListDto> GetList(Guid productId);
    }
}