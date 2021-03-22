using AspNetCore.Unobtrusive.Ajax;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult AddCardItem(Guid productId,string productName,decimal price,int number = 1)
        {
            List<CustomerCardItem> preOrders = AddPreOrder(productId,productName,price,number);

            _toastNotification.AddInfoToastMessage($"محصول به سید شما اضافه شد ");
            return PartialView("_CustomerCard",preOrders);
        }

        public IActionResult UpdateCardItem(Guid productId,string productName,int number = 1)
        {
            decimal price = _productService.GetLastPrice(productId)?.NewPrice ?? 0;
            return GetCustomerCarTable(productId,productName,number,price);
        }

        public IActionResult GetCustomerCarTable(Guid productId,string productName,int number,decimal price)
        {
            return PartialView("_CustomerCardTable",AddPreOrder(productId,productName,price,number));
        }

        public List<CustomerCardItem> AddPreOrder(Guid productId,string productName,decimal price,int number)
        {
            List<CustomerCardItem> preOrders = GetCustomerOrders();
            preOrders.RemoveAll(x => x.productId == productId);

            preOrders.Add(new CustomerCardItem()
            {
                productId = productId,
                Number = number,
                Price = price,
                ProductName = productName,
                Total = number * price
            });
            UpdatePreOrderCookies(preOrders);
            return preOrders;
        }

        private void UpdatePreOrderCookies(List<CustomerCardItem> preOrders)
        {
            Response.Cookies.Append("PreOrderInOnlineShop",JsonSerializer.Serialize(preOrders),new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
        }

        private List<CustomerCardItem> GetCustomerOrders()
        {
            string preOrdercookie = _httpContextAccessor.HttpContext.Request.Cookies["PreOrderInOnlineShop"];
            return preOrdercookie == null ? new List<CustomerCardItem>() : JsonSerializer.Deserialize<List<CustomerCardItem>>(preOrdercookie);
        }

        [AjaxOnly]
        public IActionResult RemovePreOrder(Guid productId)
        {
            List<CustomerCardItem> preOrders = GetCustomerOrders();
            preOrders.RemoveAll(x => x.productId == productId);
            UpdatePreOrderCookies(preOrders);
            _toastNotification.AddInfoToastMessage($"محصول با موفقیت از سبد حذف گردید");
            return PartialView("_CustomerCard",preOrders);
        }

        [HttpGet]
        public IActionResult DisplayCard()
        {
            return View(GetCustomerOrders());
        }
    }
}