using AutoMapper;
using AutoMapper.QueryableExtensions;
<<<<<<< HEAD
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
using OnlineShop.Common.Enums;
using OnlineShop.DataLayer.Context;
using OnlineShop.DataLayer.Repository;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
<<<<<<< HEAD
using OnlineShop.ViewModels.Base;
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
using System;
using System.Linq;

namespace OnlineShop.Services.Services.Area.Base
{
<<<<<<< HEAD
    public class ItemSectionService:EntityService<ItemSection,ItemSectionDto>, IItemSectionService
    {
        public ItemSectionService(IUnitOfWork unitOfWork,IMapper mapper,IRepository<ItemSection> repository) : base(unitOfWork,mapper,repository)
=======
    public class ItemSectionService : EntityService<ItemSection, ItemSectionDto>, IItemSectionService
    {
        public ItemSectionService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<ItemSection> repository) : base(unitOfWork, mapper, repository)
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        { }

        public IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null)
        {
            return GetAllNoTracking()
<<<<<<< HEAD
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ItemSectionListDto>(_mapper.ConfigurationProvider);
        }

        public IQueryable<ItemSectionListDto> GetListItemSection(ItemSectionType itemSectionType)
        {
            return GetAllNoTracking()
                .Where(row => !row.InActive
                && (row.itemSectionType == itemSectionType)
=======
                .Where(row => !row.IsDeleted && !row.InActive
                && (itemSectionType == null || row.itemSectionType == itemSectionType)
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
                && row.FromDate <= DateTime.Now && DateTime.Now <= row.ToDate)
                .OrderByDescending(x => x.CreateOn)
                .ProjectTo<ItemSectionListDto>(_mapper.ConfigurationProvider);
        }

<<<<<<< HEAD
        public ValidationResultvm CheckEntry(bool add,ItemSectionDto item)
        {
            var result = new ValidationResultvm() { IsValid = true,Message = string.Empty };

            if(GetAllNoTracking().Any(row => (!add || row.Id != item.Id) && row.ProductId == item.ProductId && !row.InActive &&
             row.FromDate <= item.FromDate && item.FromDate <= row.ToDate &&
             row.ToDate <= item.ToDate && item.ToDate <= row.ToDate &&
             item.ItemSectionType == row.itemSectionType))
            {
                result.IsValid = false;
                result.AppendMessage(Resource.Resource.AddExists);
            }

            return result;
        }

        public ItemSectionListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id),new ItemSectionListDto());
=======
        public ItemSectionListDto GetGeneralInfo(Guid id)
        {
            return _mapper.Map(Get(id), new ItemSectionListDto());
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        }
    }
}