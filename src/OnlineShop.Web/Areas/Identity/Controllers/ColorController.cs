using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Entities.Entities.Area.Base.Colors;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "زنگ", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.UiKit, Icon = "trash", Name = nameof(Resource.Resource.Color), order = 3)]
    public class ColorController : BaseController
    {
        private readonly IColorService _ColorService;
        private readonly IMapper _mapper;


        public ColorController(IColorService ColorService, IMapper mapper)
        {
            _ColorService = ColorService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده رنگ ها", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-ad", Name = nameof(Resource.Resource.Color), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ColorService.GetAll().ToList(), new List<ColorDto>());

            return Json(new { Data = list });

        }


        [HttpGet]
        [ActionInfo(IconType = IconType.UiKit, Icon = "happy", Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ColorService.Get(id);
            var ColorDTo = _mapper.Map<Color, ColorDto>(x);
            return View(ColorDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ColorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.UiKit, Icon = "happy", Name = nameof(Resource.Resource.Add), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Add(dto);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {

            _ColorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}