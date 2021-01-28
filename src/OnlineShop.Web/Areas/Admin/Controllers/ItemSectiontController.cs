using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Admin;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Areas.Admin.Controllers;
using OnlineShop.Web.Classes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [Authorize(Roles = ConstantRoles.Admin)]
    [BreadCrumb(Title = "مدیریت بخش های سایت",UseDefaultRouteUrl = true,Order = 0)]
    [Display(Name = "مدیریت بخش های سایت")]
    [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-archive",Name = nameof(Resource.Resource.ItemSection),order = 3)]
    public class ItemSectionController:BaseController
    {
        private readonly IItemSectionService _ItemSectionService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ItemSectionController(IItemSectionService ItemSectionService,
            IProductService productService
            ,IMapper mapper
            )
        {
            _ItemSectionService = ItemSectionService;
            _productService = productService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "",Order = 1)]
        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-list",Name = nameof(Resource.Resource.ItemSectionList),order = 1)]
        public IActionResult Index() => View();

        public JsonResult ReadData() => Json(new { Data = _ItemSectionService.GetList() });

        //public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _ItemSectionService.GetGeneralInfo(id));

        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ProductPreView),order = 2)]
        [HttpGet]
        public IActionResult PreView()
        {
            return View();
        }

        public async Task<IActionResult> PreView(int page,ItemSectionType itemSectionType)
        {
            return View(await PaginatedList<ItemSectionListDto>.CreateAsync(_ItemSectionService.GetList(itemSectionType),page));
        }

        [Menu(IconType = IconType.FontAwesome5,Icon = "fas fa-plus",Name = nameof(Resource.Resource.ItemSectionAdd),order = 2)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ItemSectionDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _ItemSectionService.AddAsync(dto.Initialize()));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4,Icon = "fas fa-edit",Name = nameof(Resource.Resource.ItemSectionEdit))]
        public IActionResult Edit(Guid id)
        {
            var item = _ItemSectionService.Get(id);
            var ItemSectionGroupDTo = _mapper.Map<ItemSection,ItemSectionDto>(item);
            return View(ItemSectionGroupDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemSectionDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _ItemSectionService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var result = _ItemSectionService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}