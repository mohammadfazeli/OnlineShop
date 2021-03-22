using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Area.Base.Section;
using OnlineShop.ViewModels.Area.Base.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Services.Area.Base
{
    public class SectionService:EntityService<Section,SectionDto>, ISectionService
    {
        private readonly IProductService _productService;

        public SectionService(IUnitOfWork unitOfWork,IMapper mapper,
            IRepository<Section> repository,
            IProductService productService) : base(unitOfWork,mapper,repository)
        {
            this._productService = productService;
        }

        public async Task<List<SectionDetailListDro>> GetSections()
        {
            return await GetAll()
               .Where(x => !x.InActive && x.ItemSections != null
               && x.ItemSections.Any(i => !i.IsDeleted && !i.InActive /*&& ((i.FromDate) >= DateTime.Now.Date && DateTime.Now.Date <= (i.ToDate))*/))
               .Select(s => new SectionDetailListDro()
               {
                   Id = s.Id,
                   SectionName = s.Name,
                   Items = s.ItemSections.Select(ss => _productService.CastToProductGeneralInfo(ss.Product)
               ).ToList()
               }).ToListAsync();
        }
    }
}