using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductDetailService : EntityService<ProductDetail, ProductDetailDto>, IProductDetailService
    {
        public ProductDetailService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ProductDetail> repository)
            : base(unitOfWork, mapper, repository)
        {
        }

        public List<ProductDetailListDto> GetList(Guid productId)
        {
            var list = GetAll()
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.CreateOn).ToList();
            return _mapper.Map(list, new List<ProductDetailListDto>());
        }

        public ProductDetailListDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ProductDetailListDto());
        }
    }
}