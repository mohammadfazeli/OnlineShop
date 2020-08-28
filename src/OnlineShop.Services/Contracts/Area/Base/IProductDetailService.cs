using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductDetails;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductDetailService : IEntityService<ProductDetail, ProductDetailDto>
    {
        List<ProductDetailListDto> GetList(Guid productId);

        ProductDetailListDto GetInfo(Guid id);
    }
}