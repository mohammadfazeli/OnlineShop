using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "محصول", UseDefaultRouteUrl = true, Order = 0)]
    [Display(Name = "محصول")]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-archive", Name = nameof(Resource.Resource.Product), order = 3)]
    public class ProductController : BaseController
    {
        private readonly IProductService _ProductService;
        private readonly IProductGroupService _productGroupService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService,
            IProductGroupService productGroupService
            , IMapper mapper)
        {
            _ProductService = ProductService;
            _productGroupService = productGroupService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده محصولات", Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductGroupList), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ProductService.GetAll().ToList(), new List<ProdcutListDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductGroupAdd), order = 2)]
        public IActionResult Create(Guid id = new Guid())
        {
            ViewBag.ProductGroupItems = new SelectList(_productGroupService.GetAll(), "Id", "Name", selectedValue: id == new Guid() ? "" : id.ToString());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdcutDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductService.Add(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductGroupEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ProductService.Get(id);
            var ProductGroupDTo = _mapper.Map<Product, ProdcutDto>(x);
            ViewBag.ProductGroupItems = new SelectList(_productGroupService.GetAll(), "Id", "Name", new { ProductGroupDTo.ProductGroupId });
            return View(ProductGroupDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProdcutDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ProductService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ProductService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}