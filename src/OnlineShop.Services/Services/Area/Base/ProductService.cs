using AutoMapper;
using OnlineShop.Common.Enum;
using OnlineShop.Common.ViewModel;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Attachments;
using OnlineShop.ViewModels.Area.Base.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services
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