using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductPriceModificatin;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "قیمت گذاری محصول", UseDefaultRouteUrl = true, Order = 0)]
    [Display(Name = "قیمت گذاری محصول")]
    public class ProductPriceModificatinController : BaseController
    {
        private readonly IProductPriceModificatinService _ProductPriceModificatinService;
        private readonly IMapper _mapper;

        public ProductPriceModificatinController(IProductPriceModificatinService ProductPriceModificatinService,
            IMapper mapper)
        {
            _ProductPriceModificatinService = ProductPriceModificatinService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = " لیست قیمت گذاری ", Order = 1)]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductPriceModificatinList))]
        public IActionResult Index(Guid id)
        {
            return View(new ProductPriceModificatinListDto() { ProductDetailId = id });
        }

        public JsonResult ReadData(Guid productDetailId)
        {
            return Json(new { Data = _ProductPriceModificatinService.GetList(productDetailId) });
        }

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _ProductPriceModificatinService.GetInfo(id));

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductPriceModificatinAdd))]
        public IActionResult Create(Guid id)
        {
            return View(new ProductPriceModificatinDto() { ProductDetailId = id , FromDate=DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductPriceModificatinDto dto, IFormFileCollection Photo)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _ProductPriceModificatinService.AddAsync(dto.Initialize()));

            return RedirectToActionPermanent(nameof(Index), new { id = dto.ProductDetailId });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductPriceModificatinEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _ProductPriceModificatinService.Get(id);
            var ProductPriceModificatinDTo = _mapper.Map<ProductPriceModificatin, ProductPriceModificatinDto>(item);
            return View(ProductPriceModificatinDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductPriceModificatinDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductPriceModificatinService.Update(dto);
            return RedirectToActionPermanent(nameof(Index), new { id = dto.ProductDetailId });
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var item = _ProductPriceModificatinService.Get(id).ProductDetailId;
            var result = _ProductPriceModificatinService.Delete(id);

            return RedirectToActionPermanent(nameof(Index), new { id = item });
        }
    }
}