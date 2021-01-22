using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Contracts.Area.Base;
using System;

namespace OnlineShop.Web.ViewComponents
{
    public class ProductRelatedViewComponent:ViewComponent
    {
        private readonly IProductRelatedService _productRelatedService;

        public ProductRelatedViewComponent(IProductRelatedService productRelatedService)
        {
            _productRelatedService = productRelatedService;
        }

        public IViewComponentResult Invoke(Guid productId)
        {
            var itemSections = _productRelatedService.GetRelatedItems(productId);
            return View(itemSections);
        }
    }
}