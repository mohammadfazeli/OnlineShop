using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Models;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "مدل", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome4, Icon = "	fa fa-share", Name = nameof(Resource.Resource.Model), order = 4)]
    public class ModelController : BaseController
    {
        private readonly IModelService _ModelService;
        private readonly IMapper _mapper;

        public ModelController(IModelService ModelService, IMapper mapper)
        {
            _ModelService = ModelService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "مشاهده مدل ها", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.UiKit, Icon = "list", Name = nameof(Resource.Resource.Model), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ModelService.GetAll().ToList(), new List<ModelDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.UiKit, Icon = "file-edit", Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ModelService.Get(id);
            var ModelDTo = _mapper.Map<Model, ModelDto>(x);
            return View(ModelDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ModelDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ModelService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.UiKit, Icon = "plus", Name = nameof(Resource.Resource.Add), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ModelDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ModelService.Add(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ModelService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}