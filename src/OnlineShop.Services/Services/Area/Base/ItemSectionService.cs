using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineShop.Common.Enums;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using System;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
    public class ItemSectionService:EntityService<ItemSection,ItemSectionDto>, IItemSectionService
    {
        public ItemSectionService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ItemSection> repository) : base(unitOfWork,mapper,repository)

        { }

        public IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null)
        {
            return GetAllNoTracking()
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ItemSectionListDto>(_mapper.ConfigurationProvider);
        }

        public IQueryable<ProdcutItemDto> GeProductItems(ItemSectionType? itemSectionType = null)
        {
            return GetAllNoTracking()
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ProdcutItemDto>(_mapper.ConfigurationProvider);
        }

        //public IQueryable<ItemSectionListDto> GetListItemSection(ItemSectionType itemSectionType)
        //{
        //    //return GetAllNoTracking()
        //    //    .Where(row => !row.InActive
        //    //    && (row.itemSectionType == itemSectionType)
        //    //    .Where(row => !row.IsDeleted && !row.InActive
        //    //    && (itemSectionType == null || row.itemSectionType == itemSectionType)

        //    //    && row.FromDate <= DateTime.Now && DateTime.Now <= row.ToDate)
        //    //    .OrderByDescending(x => x.CreateOn)
        //    //    .ProjectTo<ItemSectionListDto>(_mapper.ConfigurationProvider);
        //    return List<ItemSectionListDto>();
        //}

        public ValidationResultvm CheckEntry(bool add,ItemSectionDto item)
        {
            var result = new ValidationResultvm() { IsValid = true,Message = string.Empty };

            if(GetAllNoTracking().Any(row => (!add || row.Id != item.Id) && row.ProductId == item.ProductId && !row.InActive &&
             row.FromDate <= item.FromDate && item.FromDate <= row.ToDate &&
             row.ToDate <= item.ToDate && item.ToDate <= row.ToDate &&
             item.SectionId == row.SectionId))
            {
                result.IsValid = false;
                result.AppendMessage(Resource.Resource.AddExists);
            }

            return result;
        }

        public ItemSectionListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ItemSectionListDto());
        }

        public IQueryable<ItemSectionListDto> GetListItemSection(ItemSectionType itemSectionType)
        {
            throw new NotImplementedException();
        }
    }
}