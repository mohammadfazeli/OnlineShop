using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "وِیژگی محصول",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "وِیژگی محصول")]
    public class ProductSpecificationController:BaseController
    {
        private readonly IProductSpecificationService _ProductSpecificationService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductSpecificationController(
            IProductSpecificationService ProductSpecificationService,
            IProductService productService,
            IMapper mapper)
        {
            _ProductSpecificationService = ProductSpecificationService;
            this._productService = productService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده وِیژگی محصول",Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-list",Name = nameof(Resource.Resource.ProductSpecificationList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductSpecificationListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _ProductSpecificationService.GetList(productId) });
        }

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail",_ProductSpecificationService.GetInfo(id));

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductSpecificationAdd))]
        public IActionResult Create(Guid id)
        {
            var vm = new ProductSpecificationDto()
            {
                ProductId = id,
                ProductDropDown = _productService.GetDropDown(id)
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductSpecificationDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _ProductSpecificationService.AddAsync(dto.Initialize()));

            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ProductSpecificationEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _ProductSpecificationService.Get(id);
            var ProductSpecificationDTo = _mapper.Map<ProductSpecification,ProductSpecificationDto>(item);

            ProductSpecificationDTo.ProductDropDown = _productService.GetDropDown(ProductSpecificationDTo.ProductId);
            return View(ProductSpecificationDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductSpecificationDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var updateStatusvm = _ProductSpecificationService.Update(dto);
            return RedirectToActionPermanent(nameof(Index),new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _ProductSpecificationService.Get(id).ProductId;
            var result = _ProductSpecificationService.Delete(id);

            return RedirectToActionPermanent(nameof(Index),new { id = item });
        }
    }
}