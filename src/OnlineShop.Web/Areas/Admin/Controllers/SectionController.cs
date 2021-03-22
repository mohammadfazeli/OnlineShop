using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Section;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "بخش",UseDefaultRouteUrl = true,Order = 0)]
    [Menu(IconType = IconType.FontAwesome4,Icon = "	fa fa-share",Name = nameof(Resource.Resource.Section),order = 4)]
    public class SectionController:BaseController
    {
        private readonly ISectionService _SectionService;
        private readonly IMapper _mapper;

        public SectionController(ISectionService SectionService,IMapper mapper)
        {
            _SectionService = SectionService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده بخش",TitleResourceType = typeof(Resource.Resource),Order = 1)]
        [Menu(IconType = IconType.UiKit,Icon = "list",Name = nameof(Resource.Resource.Section),order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
         => Json(new { Data = _mapper.Map(_SectionService.GetAll().ToList(),new List<SectionDto>()) });

        [HttpGet]
        [ActionInfo(IconType = IconType.UiKit,Icon = "file-edit",Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
         => View(_mapper.Map<Section,SectionDto>(_SectionService.Get(id)));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SectionDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _SectionService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.UiKit,Icon = "plus",Name = nameof(Resource.Resource.Add),order = 2)]
        public IActionResult Create()
        => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SectionDto dto)
        {
            if(!ModelState.IsValid)
            {
                return View(dto);
            }

            _SectionService.Add(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _SectionService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}