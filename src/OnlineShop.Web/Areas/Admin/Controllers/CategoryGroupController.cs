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
using OnlineShop.ViewModels.Area.Base.categories.CategoryGroup;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "گروه دسته بندی",UseDefaultRouteUrl = true,Order = 0)]
    [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-paint-brush",Name = nameof(Resource.Resource.CategoryGroup),order = 3)]
    public class CategoryGroupController:BaseController
    {
        private readonly ICategoryGroupService _CategoryGroupService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CategoryGroupController(ICategoryGroupService CategoryGroupService,IMapper mapper,
            IToastNotification toastNotification)
        {
            _CategoryGroupService = CategoryGroupService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست گروه دسته بندی ها",TitleResourceType = typeof(Resource.Resource),Order = 1)]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-list",Name = nameof(Resource.Resource.List),order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            return Json(new { Data = _CategoryGroupService.CastToListDto<CategoryGroupListDto>(_CategoryGroupService.GetAllNoTracking()) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _CategoryGroupService.Get(id);
            var CategoryGroupDTo = _mapper.Map<CategoryGroup,CategoryGroupDto>(x);
            return View(CategoryGroupDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryGroupDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CategoryGroupService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.Add),order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryGroupDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CategoryGroupService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _CategoryGroupService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}