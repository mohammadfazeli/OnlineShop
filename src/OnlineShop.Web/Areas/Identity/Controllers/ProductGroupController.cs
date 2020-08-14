using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ProductGroups;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "گروه محصول", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fab fa-codepen", Name = nameof(Resource.Resource.ProductGroup), order = 3)]
    public class ProductGroupController : BaseController
    {
        private readonly IProductGroupService _ProductGroupService;
        private readonly IMapper _mapper;

        public ProductGroupController(IProductGroupService ProductGroupService, IMapper mapper)
        {
            _ProductGroupService = ProductGroupService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "لیست گروه محصولات", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductGroupList), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ProductGroupService.GetAll().ToList(), new List<ProductGroupDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductGroupEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ProductGroupService.Get(id);
            var ProductGroupDTo = _mapper.Map<ProductGroup, ProductGroupDto>(x);
            return View(ProductGroupDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductGroupDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductGroupService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductGroupAdd), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductGroupDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductGroupService.Add(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ProductGroupService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}