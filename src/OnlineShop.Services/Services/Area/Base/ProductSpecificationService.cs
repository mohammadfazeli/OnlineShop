using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using System;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductSpecificationService : EntityService<ProductSpecification, ProductSpecificationDto>, IProductSpecificationService
    {
        public ProductSpecificationService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ProductSpecification> repository
            ) : base(unitOfWork, mapper, repository)
        {
        }

        public IQueryable<ProductSpecificationListDto> GetList(Guid productId)
        {
            return GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ProductSpecificationListDto>(_mapper.ConfigurationProvider);
        }

        public ProductSpecificationListDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ProductSpecificationListDto());
        }
    }
}