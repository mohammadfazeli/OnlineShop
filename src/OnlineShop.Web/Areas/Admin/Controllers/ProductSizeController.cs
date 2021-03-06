using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Common.ViewModel;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSizes;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "اندازه های محصول",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "اندازه های محصول")]
    public class ProductSizeController:BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductSizeService _productSizeService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly ISizeService _sizeService;

        public ProductSizeController(
            IProductService productService,
            IProductSizeService productSizeService,
            IMapper mapper,
            IToastNotification toastNotification,
            ISizeService sizeService)
        {
            _productService = productService;
            _productSizeService = productSizeService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _sizeService = sizeService;
        }

        [BreadCrumb(Title = "مشاهده اندازه های محصول",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductDetailList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductSizeListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _productSizeService.GetList(productId) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.Add))]
        public IActionResult Create(Guid id)
        {
            var vm = new ProductSizesDto()
            {
                ProductId = id,
                ProductDropDown = _productService.GetDropDown(id),
                SizeDropDown = _sizeService.GetDropDown()
            };
            return View(vm);
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductSizesDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productSizeService.AddAsync(dto.Initialize()));
            return Json(new ResultAjaxvm { Message = result.Message,Status = result.CreateStatus.ToString() });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductDetailEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _productSizeService.Get(id);
            var ProductSizeDto = _mapper.Map<ProductSize,ProductSizesDto>(item);

            ProductSizeDto.ProductDropDown = _productService.GetDropDown(ProductSizeDto.ProductId);
            ProductSizeDto.SizeDropDown = _productService.GetDropDown(ProductSizeDto.SizeId);
            return View(ProductSizeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductSizesDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = _productSizeService.Update(dto);
            PushUpdateMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Remove(Guid id)
        {
            var result = _productSizeService.Delete(id);

            return Json(new ResultAjaxvm { Message = result.Message,Status = result.DeleteStatus.ToString() });

            //PushDeleteMessage(_toastNotification,result);

            //return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}