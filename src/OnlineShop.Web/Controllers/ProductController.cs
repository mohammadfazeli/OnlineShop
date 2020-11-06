﻿using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Common.IdentityToolkit;
using OnlineShop.Services.Contracts.Area.Base;
using System;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService,
            IToastNotification toastNotification)
        {
            _productService = productService;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index(Guid? Id = null)
        {
            var model = _productService.GetGeneralInfo(id: Id.Value);
            _toastNotification.AddSuccessToastMessage("اولین پیغام");
            return View(model);
        }

        [BreadCrumb(Title = "خطا", Order = 1)]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// To test automatic challenge after redirecting from another site
        /// Sample URL: http://localhost:5000/Home/CallBackResult?token=1&status=2&orderId=3&terminalNo=4&rrn=5
        /// </summary>
        [Authorize]
        public IActionResult CallBackResult(long token, string status, string orderId, string terminalNo, string rrn)
        {
            var userId = User.Identity.GetUserId();
            return Json(new { userId, token, status, orderId, terminalNo, rrn });
        }
    }
}