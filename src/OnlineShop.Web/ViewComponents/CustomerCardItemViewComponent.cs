using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.ViewModels.Area;
using System.Collections.Generic;
using System.Text.Json;

namespace OnlineShop.Web.ViewComponents
{
    public class CustomerCardItemViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerCardItemViewComponent(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IViewComponentResult Invoke()
        {
            var preOrdercookie = _httpContextAccessor.HttpContext.Request.Cookies["PreOrderInOnlineShop"];
            var preOrders = preOrdercookie == null ? new List<CustomerCardItem>() : JsonSerializer.Deserialize<List<CustomerCardItem>>(preOrdercookie);
            return View(preOrders);
        }
    }
}