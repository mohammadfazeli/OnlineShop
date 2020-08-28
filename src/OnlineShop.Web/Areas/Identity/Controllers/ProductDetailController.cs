using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductDetails;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "جزئیات محصول", UseDefaultRouteUrl = true, Order = 0)]
    [Display(Name = "جزئیات محصول")]
    public class ProductDetailController : BaseController
    {
        private readonly IProductDetailService _ProductDetailService;
        private readonly IColorService colorService;
        private readonly IProviderService providerService;
        private readonly IProductService productService;
        private readonly IModelService modelService;
        private readonly IMapper _mapper;

        public ProductDetailController(IProductDetailService productDetailService,
            IColorService colorService,
            IProviderService providerService,
            IProductService productService,
            IModelService modelService,
            IMapper mapper)
        {
            _ProductDetailService = productDetailService;
            this.colorService = colorService;
            this.providerService = providerService;
            this.productService = productService;
            this.modelService = modelService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده جزئیات محصول", Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductDetailList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductDetailListDto() { ProductId = id });
        }

        public JsonResult ReadData(Guid productId)
        {
            return Json(new { Data = _ProductDetailService.GetList(productId) });
        }

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _ProductDetailService.GetInfo(id));

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductDetailAdd))]
        public IActionResult Create(Guid id)
        {
            ViewBag.colorItems = colorService.GetSelectList();
            ViewBag.modelItems = modelService.GetSelectList();
            ViewBag.providerItems = providerService.GetSelectList();
            ViewBag.ProductItems = productService.GetSelectList(id);
            return View(new ProductDetailDto() { ProductId = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductDetailDto dto, IFormFileCollection Photo)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _ProductDetailService.AddAsync(dto.Initialize()));

            return RedirectToActionPermanent(nameof(Index), new { id = dto.ProductId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductDetailEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _ProductDetailService.Get(id);
            var ProductDetailDTo = _mapper.Map<ProductDetail, ProductDetailDto>(item);

            ViewBag.colorItems = colorService.GetSelectList(ProductDetailDTo.ColorId);
            ViewBag.modelItems = modelService.GetSelectList(ProductDetailDTo.ModelId);
            ViewBag.providerItems = providerService.GetSelectList(ProductDetailDTo.ProviderId);
            ViewBag.ProductItems = productService.GetSelectList(ProductDetailDTo.ProductId);
            return View(ProductDetailDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductDetailDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductDetailService.Update(dto);
            return RedirectToActionPermanent(nameof(Index), new { id = dto.ProductId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _ProductDetailService.Get(id).ProductId;
            var result = _ProductDetailService.Delete(id);

            return RedirectToActionPermanent(nameof(Index), new { id = item });
        }
    }
}