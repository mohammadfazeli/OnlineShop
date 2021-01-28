using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "برچسب های محصول",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "برچسب های محصول")]
    public class ProductTagController:BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductTagService _productTagService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ProductTagController(
            IProductService productService,
            IProductTagService productTagService,
            IMapper mapper,
            IToastNotification toastNotification)
        {
            _productService = productService;
            _productTagService = productTagService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "مشاهده برچسب های محصول",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductTags))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductTagListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _productTagService.GetList(productId) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductTagAdd))]
        public IActionResult Create(Guid id)
        {
            var vm = new ProductTagsDto()
            {
                ProductId = id,
                ProductDropDown = _productService.GetDropDown(id),
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductTagsDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productTagService.AddAsync(dto.Initialize()));
            PushAddMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductTagEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _productTagService.Get(id);
            var ProductTagDto = _mapper.Map<ProductTags,ProductTagsDto>(item);

            ProductTagDto.ProductDropDown = _productService.GetDropDown(ProductTagDto.ProductId);
            return View(ProductTagDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductTagsDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = _productTagService.Update(dto);
            PushUpdateMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _productTagService.Get(id).ProductId;
            var result = _productTagService.Delete(id);
            PushDeleteMessage(_toastNotification,result);

            return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}