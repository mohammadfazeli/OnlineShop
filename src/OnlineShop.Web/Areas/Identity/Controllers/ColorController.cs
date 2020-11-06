using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "رنگ", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-paint-brush", Name = nameof(Resource.Resource.Color), order = 3)]
    public class ColorController : BaseController
    {
        private readonly IColorService _ColorService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ColorController(IColorService ColorService, IMapper mapper,
            IToastNotification toastNotification)
        {
            _ColorService = ColorService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست رنگ ها", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ColorList), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ColorService.GetAll().ToList(), new List<ColorstDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ColorEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ColorService.Get(id);
            var ColorDTo = _mapper.Map<Color, ColorstDto>(x);
            return View(ColorDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ColorstDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ColorAdd), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColorstDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return Content("");
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ColorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}