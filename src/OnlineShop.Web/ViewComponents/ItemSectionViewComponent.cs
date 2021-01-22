using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Enums;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class ItemSectionViewComponent : ViewComponent
    {
        private readonly IItemSectionService _itemSectionService;

        public ItemSectionViewComponent(IItemSectionService itemSectionService)
        {
            _itemSectionService = itemSectionService;
        }

        public IViewComponentResult Invoke(ItemSectionType itemSectionType)
        {
<<<<<<< HEAD
            var itemSections = _itemSectionService.GetListItemSection(itemSectionType);
=======
            var itemSections = _itemSectionService.GetList(itemSectionType);
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
            return View(itemSections);
        }
    }
}