using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Sizes;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "سایز",UseDefaultRouteUrl = true,Order = 0)]
    [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-paint-brush",Name = nameof(Resource.Resource.Size),order = 3)]
    public class SizeController:BaseController
    {
        private readonly ISizeService _SizeService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public SizeController(ISizeService SizeService,IMapper mapper,
            IToastNotification toastNotification)
        {
            _SizeService = SizeService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست سایز ها",TitleResourceType = typeof(Resource.Resource),Order = 1)]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-list",Name = nameof(Resource.Resource.SizeList),order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_SizeService.GetAll().ToList(),new List<SizeDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.SizeEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _SizeService.Get(id);
            var SizeDTo = _mapper.Map<Size,SizeDto>(x);
            return View(SizeDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SizeDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _SizeService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.SizeAdd),order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SizeDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _SizeService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return Content("");
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _SizeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}