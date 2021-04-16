using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.categories.Category;
using OnlineShop.Web.Classes;
using System;
using System.Linq.Expressions;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = " دسته بندی",UseDefaultRouteUrl = true,Order = 0)]
    [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-paint-brush",Name = nameof(Resource.Resource.Category),order = 3)]
    public class CategoryController:BaseController
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        private readonly ICategoryGroupService _categoryGroupService;
        private readonly IToastNotification _toastNotification;

        public CategoryController(ICategoryService CategoryService,IMapper mapper,
            ICategoryGroupService categoryGroupService,
            IToastNotification toastNotification)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
            _categoryGroupService = categoryGroupService;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست  دسته بندی ها",TitleResourceType = typeof(Resource.Resource),Order = 1)]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-list",Name = nameof(Resource.Resource.List),order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            return Json(new { Data = _CategoryService.CastToListDto<CategoryListDto>(_CategoryService.GetAll()) });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _CategoryService.Get(id);
            var CategoryDTo = _mapper.Map<Category,CategoryDto>(x);
            CategoryDTo.CategoryGroupDropDown = _categoryGroupService.GetDropDown(x.CategoryGroupId);
            Expression<Func<Category,bool>> filter = x => x.Id != id;
            CategoryDTo.ParentCategoryDropDown = _CategoryService.GetDropDown(x.ParentCategoryId,predicate: filter);
            return View(CategoryDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CategoryService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryDto()
            {
                CategoryGroupDropDown = _categoryGroupService.GetDropDown(),
                ParentCategoryDropDown = _CategoryService.GetDropDown()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _CategoryService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _CategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}