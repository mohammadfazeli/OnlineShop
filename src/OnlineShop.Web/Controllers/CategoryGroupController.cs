using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Products;
using OnlineShop.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "دسته بندی کالاها", UseDefaultRouteUrl = true, Order = 0)]
    public class CategoryGroupController : SiteController
    {
        private readonly IProductService _productService;
        private readonly IToastNotification _toastNotification;
        private readonly IModelService _modelService;
        private readonly IProductGroupService _productGroupService;
        private readonly ISizeService _sizeService;

        private readonly IColorService _colorService;

        private readonly ICategoryGroupService _categoryGroupService;

        public CategoryGroupController(IProductService productService,
            IToastNotification toastNotification,
            IModelService modelService, IProductGroupService productGroupService,
            ISizeService sizeService, IColorService colorService,
            ICategoryGroupService categoryGroupService)
        {
            _productService = productService;
            _toastNotification = toastNotification;
            _modelService = modelService;
            _productGroupService = productGroupService;
            _sizeService = sizeService;
            _colorService = colorService;
            _categoryGroupService = categoryGroupService;
        }

        [BreadCrumb(Title = "دسته بندی کالاها", Order = 1)]
        [Route("Category/{id}/{CategoryName}")]
        public async Task<IActionResult> Categories(Guid id, string CategoryName, int page = 1)
        {
            GeneratePageTitle($"دسته بندی کالاها{CategoryName}");
            var items = _productService.GetShopItems(new ShopDto() { CategoryId = id });
            var prodcutDto = new ShopDto()
            {
                ProdcutItems = await PaginatedList<ProdcutGeneralInfoDto>.CreateAsync(items, page, 6),
                ProductGroupCheckBoxList = _productGroupService.GetCheckBoxList("ProductGroupCheckBoxList", Resource.Resource.ProductGroup),
                ModelCheckBoxList = _modelService.GetCheckBoxList("ModelCheckBoxList", Resource.Resource.Model),
                SizeCheckBoxList = _sizeService.GetCheckBoxList("SizeCheckBoxList", Resource.Resource.Size),
                ColorCheckBoxList = _colorService.GetCheckBoxList("ColorCheckBoxList", Resource.Resource.Color),
            };

            return View(prodcutDto);
        }
    }
}