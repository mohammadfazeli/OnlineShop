using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base.Coupon;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Coupon;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "کوپن",UseDefaultRouteUrl = true,Order = 0)]
    [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-paint-brush",Name = nameof(Resource.Resource.Coupon),order = 3)]
    public class CouponController:BaseController
    {
        private readonly ICouponService _CouponService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CouponController(ICouponService CouponService,IMapper mapper,
            IToastNotification toastNotification)
        {
            _CouponService = CouponService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست کوپن ها",TitleResourceType = typeof(Resource.Resource),Order = 1)]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-list",Name = nameof(Resource.Resource.List),order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_CouponService.GetAll().ToList(),new List<CouponDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _CouponService.Get(id);
            var CouponDTo = _mapper.Map<Coupon,CouponDto>(x);
            return View(CouponDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CouponDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CouponService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.Add),order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CouponDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CouponService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return Content("");
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _CouponService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}