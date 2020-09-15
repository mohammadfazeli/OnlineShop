using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Contracts.Area.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class LastProductViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public LastProductViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke(int take = 7)
        {
            var lastproducts = _productService.GetLastProduct(take);
            return View(lastproducts);
        }
    }
}