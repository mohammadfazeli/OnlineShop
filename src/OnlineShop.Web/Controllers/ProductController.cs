using AspNetCore.Unobtrusive.Ajax;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Common.AdminToolkit;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "خانه",UseDefaultRouteUrl = true,Order = 0)]
    public class ProductController:Controller
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        private readonly IModelService _modelService;
        private readonly IProductGroupService _productGroupService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;

        public ProductController(IProductService productService,
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

        [BreadCrumb(Title = "ایندکس",Order = 1)]
        public IActionResult Index(Guid? Id = null)
        {
            var model = _productService.GetGeneralInfo(id: Id.Value);
            return View(model);
        }

        [BreadCrumb(Title = "فروشگاه",Order = 1)]
        public async Task<IActionResult> Shop(ShopDto productSearchShop,int page = 1)
        {
            var items = _productService.GetShopItems(productSearchShop);
            var prodcutDto = new ShopDto()
            {
                ProdcutItems = await PaginatedList<ProdcutItemDto>.CreateAsync(items,page,6),
                ProductGroupCheckBoxList = _productGroupService.GetCheckBoxList("ProductGroupCheckBoxList",Resource.Resource.ProductGroup),
                ModelCheckBoxList = _modelService.GetCheckBoxList("ModelCheckBoxList",Resource.Resource.Model),
                SizeCheckBoxList = _sizeService.GetCheckBoxList("SizeCheckBoxList",Resource.Resource.Size),
                ColorCheckBoxList = _colorService.GetCheckBoxList("ColorCheckBoxList",Resource.Resource.Color),
            };

            return View(prodcutDto);
        }

        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> GetShopItems(ShopDto productSearchShop,int page = 1)
        {
            var items = _productService.GetShopItems(productSearchShop);
            var prodcutDto = new ShopDto()
            {
                ProdcutItems = await PaginatedList<ProdcutItemDto>.CreateAsync(items,page,6),
            };

            return PartialView("_ShopDisplayItems",prodcutDto.ProdcutItems);
        }

        [BreadCrumb(Title = "خطا",Order = 1)]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// To test automatic challenge after redirecting from another site
        /// Sample URL: http://localhost:5000/Home/CallBackResult?token=1&status=2&orderId=3&terminalNo=4&rrn=5
        /// </summary>
        [Authorize]
        public IActionResult CallBackResult(long token,string status,string orderId,string terminalNo,string rrn)
        {
            var userId = User.Identity.GetUserId();
            return Json(new { userId,token,status,orderId,terminalNo,rrn });
        }

        public IActionResult SelectItem(Guid productDetailId)
        {
            _toastNotification.AddInfoToastMessage($"محصول به سید شما اضافه شد ");
            var items = new List<CustomerCardItem>()
            {
                new CustomerCardItem(){ Number=1 , ProductName=productDetailId.ToString() }
            };
            return PartialView("_CustomerCard",items);
        }
    }
}