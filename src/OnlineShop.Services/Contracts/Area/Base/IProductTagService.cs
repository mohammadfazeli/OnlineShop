using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductTagService:IEntityService<ProductTags,ProductTagsDto>
    {
        List<ProductTagListDto> GetList(Guid productId);
    }
}