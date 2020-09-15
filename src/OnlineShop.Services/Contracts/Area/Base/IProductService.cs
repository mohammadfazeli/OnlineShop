using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductService : IEntityService<Product, ProdcutDto>
    {
        IQueryable<ProdcutListDto> GetList();

        ProdcutListDto GetGeneralInfo(Guid id);

        IQueryable<ProdcutListDto> GetLastProduct(int take = 7);
    }
}