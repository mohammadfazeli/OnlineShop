using OnlineShop.Entities.Entities.Area.Base;
using System.Collections.Generic;

namespace OnlineShop.Services.Contracts
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        IList<Product> GetAllProducts();
    }
}