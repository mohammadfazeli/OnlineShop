﻿using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductGroups;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductGroupService : EntityService<ProductGroup, ProductGroupDto>, IProductGroupService
    {
        public ProductGroupService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ProductGroup> repository) : base(unitOfWork, mapper, repository)
        {
        }
    }
}