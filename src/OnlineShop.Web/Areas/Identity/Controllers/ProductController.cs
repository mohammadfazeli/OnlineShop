using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enum;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.Services.Identity;
using OnlineShop.ViewModels.Area.Base.Products;
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
        private readonly IProductService _ProductService;
        private readonly IAttachmentService _attachmentService;
        private readonly IProductGroupService _productGroupService;
        private readonly IMapper _mapper;
        private readonly IHubContext<Notification> _context;

        public ProductController(IProductService ProductService, IAttachmentService attachmentService,
            IProductGroupService productGroupService
            , IMapper mapper,
            IHubContext<Notification> context
            )
        {
            _ProductService = ProductService;
            _productGroupService = productGroupService;
            _attachmentService = attachmentService;
            _mapper = mapper;
            _context = context;
        }

        [BreadCrumb(Title = "مشاهده محصولات", Order = 1)]
        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-list", Name = nameof(Resource.Resource.ProductGroupList), order = 1)]
        public IActionResult Index() => View();

        public JsonResult ReadData() => Json(new { Data = _ProductService.GetList() });

        public PartialViewResult GetInfo(Guid id) => PartialView("_Detail", _ProductService.GetGeneralInfo(id));

        [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductGroupAdd), order = 2)]
        public async Task<IActionResult> PreView(int page = 1) => View(await PaginatedList<ProdcutListDto>.CreateAsync(_ProductService.GetList(), page));

        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.ProductGroupAdd), order = 2)]
        [HttpGet]
        public async Task<IActionResult> Create(Guid id = new Guid())
        {
            //await _context.Clients.All.SendAsync("initSignal", "hi farhad");
            await _context.Clients.All.SendAsync("SendNotification", $"connectionId : asd");
            var prodcutDto = new ProdcutDto() { ProductGroupDropDown = _productGroupService.GetDropDown(id) };
            return View(prodcutDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProdcutDto dto, IFormFileCollection Photo)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var result = (await _ProductService.AddAsync(dto.Initialize()));
            if (result.CreateStatus == CreateStatus.Successfully)
            {
                await _attachmentService.AddList(result.RetrunId, Photo);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome4, Icon = "fas fa-edit", Name = nameof(Resource.Resource.ProductGroupEdit))]
        public IActionResult Edit(Guid id)
        {
            var x = _ProductService.Get(id);
            var ProductGroupDTo = _mapper.Map<Product, ProdcutDto>(x);
            ProductGroupDTo.ProductGroupDropDown = _productGroupService.GetDropDown(ProductGroupDTo.ProductGroupId);
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

            _ProductService.Update(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remove(Guid id)
        {
            var result = _ProductService.Delete(id);
            if (result.DeleteStatus == DeleteStatus.Successfully)
            {
                _attachmentService.RemoveAll(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}