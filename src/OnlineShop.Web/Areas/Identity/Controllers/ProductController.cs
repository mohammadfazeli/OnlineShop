using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Services.Contracts;
using OnlineShop.ViewModels.Area.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using OnlineShop.Common.Enum;
using OnlineShop.Web.Classes;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "محصولات", UseDefaultRouteUrl = true, Order = 0)]
    [Display(Name = "محصولات")]
    [Menu(IconType = IconType.UiKit, Icon = "user", Name = "محصولات", order = 1)]
    public class ProductController : BaseController
    {
        private readonly IPartService _PartService;
        private readonly IMapper _mapper;

        
        public ProductController(IPartService partService, IMapper mapper)
        {
            _PartService = partService;
            _mapper = mapper;
        }
        [BreadCrumb(Title = "مشاهده محصولات", Order = 1)]
        [Menu(IconType = IconType.UiKit, Icon = "user", Name = "مشاهده محصولات", order = 1)]

        public IActionResult Index()
        {

            MenuBuilder(AreaConstants.Area.IdentityArea);
            var parts = _PartService.Get(3);
            if (parts != null)
            {
                var partDto = new PartDto()
                {
                    Code = parts.Code,
                    Id = parts.Id,
                    Name = "فرهاد",
                    Title = "ثبasdasdasdasdasdasdasdت ثبت"
                };
                _PartService.Update(partDto);

            }
            else
            {
                var dsDto = new PartDto()
                {
                    Name = "محمد ",
                    Title = "ادد میشه"
                };
                _PartService.Add(dsDto);
            }

            var s = _mapper.Map(_PartService.GetAll().ToList(), new List<PartDto>());
            return View(s);

        }
        [BreadCrumb(Title = "مشاهده محصولات", Order = 1)]
        [Menu(IconType = IconType.UiKit, Icon = "folder", Name = "ثبت محصولات", order = 1)]
        public IActionResult Save()
        {

            MenuBuilder(AreaConstants.Area.IdentityArea);
            var parts = _PartService.Get(3);            
            if (parts != null)
            {
                var partDto = new PartDto()
                {
                    Code = parts.Code,
                    Id = parts.Id,
                    Name = "فرهاد",
                    Title = "ثبasdasdasdasdasdasdasdت ثبت"
                };
                _PartService.Update(partDto);

            }
            else
            {
                var dsDto = new PartDto()
                {
                    Name = "محمد ",
                    Title = "ادد میشه"
                };
                _PartService.Add(dsDto);
            }

            var s = _mapper.Map(_PartService.GetAll().ToList(), new List<PartDto>());
            return View(s);

        }
    }
}