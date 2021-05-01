using AspNetCore.Unobtrusive.Ajax;
using AutoMapper;
using DNTBreadCrumb.Core;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.Web.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Area(AreaConstants.AdminArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "ایمورت", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-paint-brush", Name = nameof(Resource.Resource.Color), order = 3)]
    public class ImportController : BaseController
    {
        private readonly IColorService _ColorService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public ImportController(IColorService ColorService, IMapper mapper,
            IToastNotification toastNotification)
        {
            _ColorService = ColorService;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "لیست ایمورت ها", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ColorList), order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var items = await GetItems(file.FileName);
            return RedirectToAction(nameof(Index));
        }

        public async Task<List<ColorstDto>> GetItems(string filename)
        {
            var items = new List<ColorstDto>();

            var file = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + filename;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(file, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        items.Add(new ColorstDto()
                        {
                            Name = reader.GetValue(0).ToString(),
                            UserCode = reader.GetValue(1).ToString(),
                            ForeignName = reader.GetValue(2).ToString(),
                        });
                    }
                }
                System.IO.File.Delete(file);
            }
            var result = await _ColorService.AddRangeAsync(items);
            return items;
        }

        public JsonResult ReadData()
        {
            var list = _mapper.Map(_ColorService.GetAll().ToList(), new List<ColorstDto>());

            return Json(new { Data = list });
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ColorEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ColorService.Get(id);
            var ColorDTo = _mapper.Map<Color, ColorstDto>(x);
            return View(ColorDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ColorstDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ColorAdd), order = 2)]
        public IActionResult Create()
        {
            return View();
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ColorstDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _ColorService.Add(dto);
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");
            return Content("");
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            _ColorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}