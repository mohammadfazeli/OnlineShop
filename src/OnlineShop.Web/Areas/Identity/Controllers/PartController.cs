using AutoMapper;
using DNTBreadCrumb.Core;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts;
using OnlineShop.ViewModels.Area.Base;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "محصولات", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.UiKit, Icon = "trash", Name = nameof(Resource.Resource.Parts), order = 2)]
    public class PartController : BaseController
    {
        private readonly IPartService _PartService;
        private readonly IMapper _mapper;


        public PartController(IPartService partService, IMapper mapper)
        {
            _PartService = partService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده قطعات", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.UiKit, Icon = "trash", Name = nameof(Resource.Resource.DisplayParts), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_PartService.GetAll().ToList(), new List<PartDto>());

            return Json(new { Data = list });

        }


        [HttpGet]
        [ActionInfo(IconType = IconType.UiKit, Icon = "happy", Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _PartService.Get(id);
            var PartDTo = _mapper.Map<Part, PartDto>(x);
            return View(PartDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PartDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _PartService.Update(dto);
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
        public IActionResult Create(PartDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _PartService.Add(dto);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {

            _PartService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}