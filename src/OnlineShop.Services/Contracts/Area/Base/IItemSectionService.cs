using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
<<<<<<< HEAD
using OnlineShop.ViewModels.Base;
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IItemSectionService : IEntityService<ItemSection, ItemSectionDto>
    {
        IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null);
<<<<<<< HEAD

        IQueryable<ItemSectionListDto> GetListItemSection(ItemSectionType itemSectionType);

        ValidationResultvm CheckEntry(bool add, ItemSectionDto item);
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
    }
}