using AspNetCore.Unobtrusive.Ajax;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Common.AdminToolkit;
using OnlineShop.Common.Enums;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "خانه",UseDefaultRouteUrl = true,Order = 0)]
    public class OrderController:SiteController
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        private readonly IModelService _modelService;
        private readonly IProductGroupService _productGroupService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;

        public OrderController(IProductService productService,
            IToastNotification toastNotification,
            IModelService modelService,IProductGroupService productGroupService,ISizeService sizeService,IColorService colorService)
        {
            _productService = productService;
            _toastNotification = toastNotification;
            _modelService = modelService;
            _productGroupService = productGroupService;
            _sizeService = sizeService;
            _colorService = colorService;
        }

        [BreadCrumb(Title = "سفارش گذاری",Order = 1)]
        public IActionResult Register()
        {
            GeneratePageTitle("سفارش گذاری");
            return View();
        }

        //[BreadCrumb(Title = "سفارش گذاری",Order = 1)]
        //public IActionResult Register(OrderDto )
        //{
        //    GeneratePageTitle("سفارش گذاری");
        //    return View();
        //}
    }
}