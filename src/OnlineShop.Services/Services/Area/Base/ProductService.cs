using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;

namespace OnlineShop.Services.Services
{
    public class ProductService : EntityService<Product, ProdcutDto>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Product> repository) : base(unitOfWork, mapper, repository)
        {
        }
    }
}