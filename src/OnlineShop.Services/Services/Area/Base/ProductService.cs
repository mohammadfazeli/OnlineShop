using AutoMapper;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ProductService : EntityService<Product, ProdcutDto>, IProductService
    {
        private readonly IAttachmentService _attachmentService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Product> repository
            , IAttachmentService attachmentService
            ) : base(unitOfWork, mapper, repository)
        {
            this._attachmentService = attachmentService;
        }

        public List<ProdcutListDto> GetList()
        {
            return _mapper.Map(GetAll().OrderByDescending(x => x.CreateOn).ToList(), new List<ProdcutListDto>());
        }

        public ProdcutListDto GetInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ProdcutListDto());
        }
    }
}