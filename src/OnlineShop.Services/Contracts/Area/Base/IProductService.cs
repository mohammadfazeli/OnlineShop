using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductService : IEntityService<Product, ProdcutDto>
    {
        List<ProdcutListDto> GetList();

        ProdcutListDto GetInfo(Guid id);
    }
}