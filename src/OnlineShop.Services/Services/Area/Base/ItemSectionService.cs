using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Common.Enums;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using System;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ItemSectionService : EntityService<ItemSection, ItemSectionDto>, IItemSectionService
    {
        public ItemSectionService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ItemSection> repository) : base(unitOfWork, mapper, repository)
        { }

        public IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null)
        {
            return GetAllNoTracking()
                .Where(row => !row.IsDeleted && !row.InActive
                && (itemSectionType == null || row.itemSectionType == itemSectionType)
                && row.FromDate <= DateTime.Now && DateTime.Now <= row.ToDate)
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ItemSectionListDto>(_mapper.ConfigurationProvider);
        }

        public ItemSectionListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ItemSectionListDto());
        }
    }
}