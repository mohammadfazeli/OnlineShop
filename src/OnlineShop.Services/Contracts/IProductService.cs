using System.Collections.Generic;
using OnlineShop.Entities;

namespace OnlineShop.Services.Contracts
{
    public interface IProductService
    {
        void AddNewProduct(Product product);
        IList<Product> GetAllProducts();
    }
}