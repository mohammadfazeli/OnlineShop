using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductService : IEntityService<Product, ProdcutDto>
    {
    }
}