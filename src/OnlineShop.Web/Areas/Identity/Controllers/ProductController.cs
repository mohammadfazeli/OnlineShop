using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NToastNotify;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enums;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.Services.Identity;
using OnlineShop.ViewModels.Area.Base.ItemSections;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Classes;
using OnlineShop.Web.Hubs;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [Authorize(Roles = ConstantRoles.Admin)]
    [BreadCrumb(Title = "محصول", UseDefaultRouteUrl = true, Order = 0)]
    [Display(Name = "محصول")]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-archive", Name = nameof(Resource.Resource.Product), order = 3)]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IAttachmentService _attachmentService;
        private readonly IProductGroupService _productGroupService;
        private readonly IMapper _mapper;
        private readonly IHubContext<Notification> _context;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService ProductService, IAttachmentService attachmentService,
            IProductGroupService productGroupService
            , IMapper mapper,
            IHubContext<Notification> context,
             IToastNotification toastNotification
            )
        {
            _productService = ProductService;
            _productGroupService = productGroupService;
            _attachmentService = attachmentService;
            _mapper = mapper;
            _context = context;
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "مشاهده محصولات", Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductGroupList), order = 1)]
        public IActionResult Index() => View();

        public JsonResult ReadData() => Json(new { Data = _productService.GetList() });

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _productService.GetGeneralInfo(id));

        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductPreView), order = 2)]
        public async Task<IActionResult> PreView(int page = 1) => View(await PaginatedList<ProdcutListDto>.CreateAsync(_productService.GetList(), page));

        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductGroupAdd), order = 2)]
        [HttpGet]
        public async Task<IActionResult> Create(Guid id = new Guid())
        {
            await _context.Clients.All.SendAsync("SendNotification", $"connectionId : asd");
            var prodcutDto = new ProdcutDto() { ProductGroupDropDown = _productGroupService.GetDropDown(id) };
            return View(prodcutDto);
        }

        public JsonResult SearchProduct(string Name, string UserCode, Guid? modelId)
        {
            var search = new ProductSearch()
            {
                Name = Name,
                UserCode = UserCode,
                ModelId = modelId
            };

            return Json(new { Data = _productService.SearchProduct(search) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdcutDto dto, IFormFileCollection Photo)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _productService.AddAsync(dto.Initialize()));
            if (result.CreateStatus == CreateStatus.Successfully)
            {
                await _attachmentService.AddList(result.RetrunId, Photo);
            }
            return RedirectToAction(nameof(Index));
        }

        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-Search", Name = nameof(Resource.Resource.MangmenetSugestProduct), order = 2)]
        [HttpGet]
        public IActionResult MangmenetSugestProduct(ProductSearch productSearch)
        {
            return View();
        }

        public IActionResult SubmitSugestProduct(ItemSectionDto dto)
        {
            var items = dto;
            return Content("asd");
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductGroupEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _productService.Get(id);
            var ProductGroupDTo = _mapper.Map<Product, ProdcutDto>(x);
            ProductGroupDTo.ProductGroupDropDown = _productGroupService.GetDropDown(ProductGroupDTo.ProductGroupId);
            _toastNotification.AddInfoToastMessage("شسیشیسشیسشی");
            return View(ProductGroupDTo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProdcutDto dto, IFormFile Photo)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _productService.Update(dto);
            _toastNotification.AddSuccessToastMessage("شسیشیسشیسشی");

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var result = _productService.Delete(id);
            if (result.DeleteStatus == DeleteStatus.Successfully)
            {
                _attachmentService.RemoveAll(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}