using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Provider;
using OnlineShop.Web.Classes;
using System;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "تامین کتتده", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-building", Name = nameof(Resource.Resource.Provider), order = 3)]
    public class ProviderController : BaseController
    {
        private readonly IProviderService _ProviderService;
        private readonly IMapper _mapper;

        public ProviderController(IProviderService ProviderService, IMapper mapper)
        {
            _ProviderService = ProviderService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "تامین کنندگان", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProviderList), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData() => Json(new { Data = _ProviderService.GetList() });

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _ProviderService.GetInfo(id));

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductGroupEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ProviderService.Get(id);
            var ProviderDTo = _mapper.Map<Provider, ProviderDto>(x);
            return View(ProviderDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProviderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProviderService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus-circle", Name = nameof(Resource.Resource.ProviderCreate), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProviderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProviderService.Add(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ProviderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}