using AspNetCore.Unobtrusive.Ajax;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "سبد",UseDefaultRouteUrl = true,Order = 0)]
    public class CardController:Controller
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CardController(IProductService productService,
            IToastNotification toastNotification,
            IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _toastNotification = toastNotification;
            _httpContextAccessor = httpContextAccessor;
        }

        [BreadCrumb(Title = "سبد خرید",Order = 1)]
        public IActionResult Index(Guid? Id = null)
        {
            var model = _productService.GetGeneralInfo(id: Id.Value);
            _toastNotification.AddSuccessToastMessage("اولین پیغام");
            return View(model);
        }

        [HttpPost]
        public IActionResult SelectItem(CustomerCardItem item)
        {
            var preOrdercookie = _httpContextAccessor.HttpContext.Request.Cookies["PreOrderInOnlineShop"];
            var preOrders = preOrdercookie == null ? new List<CustomerCardItem>() : JsonSerializer.Deserialize<List<CustomerCardItem>>(preOrdercookie);
            preOrders.RemoveAll(x => x.productId == item.productId);

            preOrders.Add(new CustomerCardItem()
            {
                productId = item.productId,
                Number = item.Number,
                price = _productService.GetLastPrice(item.productId).NewPrice,
                ProductName = _productService.Get(item.productId).Name,
            });

            Response.Cookies.Append("PreOrderInOnlineShop",JsonSerializer.Serialize(preOrders),new CookieOptions() { Expires = DateTime.Now.AddDays(1) });

            _toastNotification.AddInfoToastMessage($"محصول به سید شما اضافه شد ");
            return PartialView("_CustomerCard",preOrders);
        }

        [AjaxOnly]
        public IActionResult RemovePreOrder(Guid productId)
        {
            var preOrdercookie = _httpContextAccessor.HttpContext.Request.Cookies["PreOrderInOnlineShop"];
            var preOrders = preOrdercookie == null ? new List<CustomerCardItem>() : JsonSerializer.Deserialize<List<CustomerCardItem>>(preOrdercookie);
            preOrders.RemoveAll(x => x.productId == productId);
            Response.Cookies.Append("PreOrderInOnlineShop",JsonSerializer.Serialize(preOrders),new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
            _toastNotification.AddInfoToastMessage($"محصول با موفقیت از سبد حذف گردید");
            return PartialView("_CustomerCard",preOrders);
        }
    }
}