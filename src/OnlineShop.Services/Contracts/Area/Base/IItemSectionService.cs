using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using System.Linq;

namespace OnlineShop.Services.Contracts.Area.Base
{
    public interface IItemSectionService:IEntityService<ItemSection,ItemSectionDto>
    {
        IQueryable<ItemSectionListDto> GetList(ItemSectionType? itemSectionType = null);

        IQueryable<ItemSectionListDto> GetListItemSection(ItemSectionType itemSectionType);

        IQueryable<ProdcutItemDto> GeProductItems(ItemSectionType? itemSectionType = null);

        ValidationResultvm CheckEntry(bool add,ItemSectionDto item);
    }
}