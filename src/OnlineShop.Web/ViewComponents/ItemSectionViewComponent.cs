using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Enums;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class ItemSectionViewComponent:ViewComponent
    {
        private readonly IItemSectionService _itemSectionService;

        public ItemSectionViewComponent(IItemSectionService itemSectionService)
              => _itemSectionService = itemSectionService;

        public IViewComponentResult Invoke(ItemSectionType itemSectionType)
            => View(_itemSectionService.GeProductItems(itemSectionType));
    }
}