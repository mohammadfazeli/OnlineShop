﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common.Enums;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class ItemSection2ViewComponent:ViewComponent
    {
        private readonly IItemSectionService _itemSectionService;

        public ItemSection2ViewComponent(IItemSectionService itemSectionService)
        {
            _itemSectionService = itemSectionService;
        }

        public IViewComponentResult Invoke(ItemSectionType itemSectionType)
        {
            var itemSections = _itemSectionService.GetList(itemSectionType);

            return View(itemSections);
        }
    }
}