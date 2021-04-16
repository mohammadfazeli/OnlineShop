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
using OnlineShop.ViewModels.Area.Base.ProductSalePrice;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "قیمت گذاری ",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "قیمت گذاری ")]
    public class ProductSalePriceController:BaseController
    {
        private readonly IProductSalePriceService _productSalePriceService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ProductSalePriceController(IProductSalePriceService productSalePriceService,
            IMapper mapper,
            IToastNotification toastNotification)
        {
            _productSalePriceService = productSalePriceService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = " لیست قیمت گذاری ",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductSalePriceList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductSalePriceListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid ProductId)
        {
            return Json(new { Data = _productSalePriceService.GetList(ProductId) });
        }

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail",_productSalePriceService.GetInfo(id));

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductSalePriceAdd))]
        public IActionResult Create(Guid id)
        {
            return View(new ProductSalePriceDto() { ProductId = id,FromDate = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductSalePriceDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productSalePriceService.AddAsync(dto.Initialize()));

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductSalePriceEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _productSalePriceService.Get(id);
            var ProductPriceModificatinDTo = _mapper.Map<ProductSalePrice,ProductSalePriceDto>(item);
            return View(ProductPriceModificatinDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductSalePriceDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _productSalePriceService.Update(dto);
            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _productSalePriceService.Get(id).ProductId;
            var result = _productSalePriceService.Delete(id);

            return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}