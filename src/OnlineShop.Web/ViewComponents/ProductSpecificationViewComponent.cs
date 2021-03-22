using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Contracts.Area.Base;
using System;

namespace OnlineShop.Web.ViewComponents
{
    public class ProductSpecificationViewComponent:ViewComponent
    {
        private readonly IProductSpecificationService _productSpecificationService;

        public ProductSpecificationViewComponent(IProductSpecificationService productSpecificationService)
        {
            _productSpecificationService = productSpecificationService;
        }

        public IViewComponentResult Invoke(Guid productId)
        {
            var itemSections = _productSpecificationService.GetList(productId,false);
            return View(itemSections);
        }
    }
}