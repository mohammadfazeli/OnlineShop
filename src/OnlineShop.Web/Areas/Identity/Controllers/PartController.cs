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
        [Menu(IconType = IconType.UiKit, Icon = "happy", Name = nameof(Resource.Resource.DisplayParts), order = 1)]
        public IActionResult Index()
        {
          
            var s = _mapper.Map(_PartService.GetAll().ToList(), new List<PartDto>());
            return View(s);

        }
        [HttpGet]
        [ActionInfo(IconType = IconType.UiKit, Icon = "happy", Name = nameof(Resource.Resource.Edit))]
        public IActionResult Edit(Guid id)
        {
            var x = _PartService.Get(id);
            var PartDTo= _mapper.Map<Part, PartDto>(x);
            return View(PartDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PartDto dto)
        {
            var result = false;
            if (dto.Id == null)
            {
                result = _PartService.Add(dto);
            }
            else
            {
                result = _PartService.Update(dto);
                return RedirectToAction(nameof(Index));

            }

            return PartialView("_AddOrEdit", model: dto);
        }
    }
}