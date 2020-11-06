using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IItemSectionService : IEntityService<ItemSection, ItemSectionDto>
    {
        IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null);
    }
}