using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using System;
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductSpecificationService : IEntityService<ProductSpecification, ProductSpecificationDto>
    {
        IQueryable<ProductSpecificationListDto> GetList(Guid productId);

        ProductSpecificationListDto GetInfo(Guid id);
    }
}