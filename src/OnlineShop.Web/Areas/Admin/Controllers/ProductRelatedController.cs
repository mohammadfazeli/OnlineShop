using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductRelated;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = " محصول مرتبط",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "محصول مرتبط")]
    public class ProductRelatedController:BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductRelatedService _productRelatedService;
        private readonly IMapper _mapper;

        public ProductRelatedController(
            IProductService productService,
            IProductRelatedService productRelatedService,
            IMapper mapper)
        {
            _productService = productService;
            _productRelatedService = productRelatedService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده جزئیات محصول",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductDetailList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductRelatedListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _productRelatedService.GetList(productId) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductDetailAdd))]
        public IActionResult Create(Guid id)
        {
            var vm = new ProductRelatedDto()
            {
                ProductId = id,
                ProductDropDown = _productService.GetDropDown(id),
                RelatedProductDropDown = _productService.GetDropDown()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductRelatedDto dto,IFormFileCollection Photo)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productRelatedService.AddAsync(dto.Initialize()));

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductDetailEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _productRelatedService.Get(id);
            var ProductRelatedDto = _mapper.Map<ProductRelated,ProductRelatedDto>(item);

            ProductRelatedDto.ProductDropDown = _productService.GetDropDown(ProductRelatedDto.ProductId);
            ProductRelatedDto.RelatedProductDropDown = _productService.GetDropDown(ProductRelatedDto.RelatedProductId);
            return View(ProductRelatedDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductRelatedDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _productRelatedService.Update(dto);
            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _productRelatedService.Get(id).ProductId;
            var result = _productRelatedService.Delete(id);

            return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}