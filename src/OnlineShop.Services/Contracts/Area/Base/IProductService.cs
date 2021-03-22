using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IProductService:IEntityService<Product,ProdcutDto>
    {
        IQueryable<ProdcutListDto> GetList();

        ProdcutGeneralInfoDto GetGeneralInfo(Guid id);

        IQueryable<ProdcutItemDto> GetShopItems(ShopDto productSearchShop);

        IQueryable<ProdcutListDto> GetLastProduct(int take = 7);

        IQueryable<ProdcutListFullInfoDto> SearchProduct(ProductSearch productSearch);

        ProductSalePrice GetLastPrice(Guid productId);

        Task<ProdcutGeneralInfoDto> GetProdcut(Guid Id);

        ProdcutGeneralInfoDto CastToProductGeneralInfo(Product product);
    }
}