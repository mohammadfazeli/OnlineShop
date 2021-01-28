using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductColors;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "رنگ های محصول",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "رنگ های محصول")]
    public class ProductColorController:BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IColorService _colorService;

        public ProductColorController(
            IProductService productService,
            IProductColorService productColorService,
            IMapper mapper,
            IToastNotification toastNotification,
            IColorService colorService)
        {
            _productService = productService;
            _productColorService = productColorService;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _colorService = colorService;
        }

        [BreadCrumb(Title = "مشاهده رنگ های محصول",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductDetailList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductColorsListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _productColorService.GetList(productId) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductDetailAdd))]
        public IActionResult Create(Guid id)
        {
            var vm = new ProductColorsDto()
            {
                ProductId = id,
                ProductDropDown = _productService.GetDropDown(id),
                ColorDropDown = _colorService.GetDropDown()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductColorsDto dto,IFormFileCollection Photo)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productColorService.AddAsync(dto.Initialize()));
            PushAddMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductDetailEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _productColorService.Get(id);
            var ProductColorDto = _mapper.Map<ProductColor,ProductColorsDto>(item);

            ProductColorDto.ProductDropDown = _productService.GetDropDown(ProductColorDto.ProductId);
            ProductColorDto.ColorDropDown = _colorService.GetDropDown(ProductColorDto.ColorId);
            return View(ProductColorDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductColorsDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = _productColorService.Update(dto);
            PushUpdateMessage(_toastNotification,result);
            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _productColorService.Get(id).ProductId;
            var result = _productColorService.Delete(id);
            PushDeleteMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}