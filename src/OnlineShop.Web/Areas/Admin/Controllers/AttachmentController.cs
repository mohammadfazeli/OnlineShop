using AutoMapper;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Areas.Identity;
using OnlineShop.Common.Enums;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Attachments;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Classes;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    [Area(AreaConstants.IdentityArea)]
    [AllowAnonymous]
    [BreadCrumb(Title = "ضمیمه", UseDefaultRouteUrl = true, Order = 0)]
    [Menu(IconType = IconType.FontAwesome5, Icon = "fas fa-paint-brush", Name = nameof(Resource.Resource.Attachment), order = 3)]
    public class AttachmentController : BaseController
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IMapper _mapper;

        public AttachmentController(IAttachmentService AttachmentService, IMapper mapper)
        {
            _attachmentService = AttachmentService;
            _mapper = mapper;
        }

        [BreadCrumb(Title = "لیست ضمیمه ها", TitleResourceType = typeof(Resource.Resource), Order = 1)]
        public IActionResult Index(Guid id)
        {
            return View(new AttachmentListDto() { RelateId = id });
        }

        public JsonResult ReadData(Guid relatedId) => Json(new { Data = _attachmentService.GetList(relatedId) });

        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-images", Name = nameof(Resource.Resource.Attachments), order = 2)]
        public async Task<IActionResult> PreView(Guid id, int page = 1)
        {
            ViewBag.ParentId = id;
            return View(await PaginatedList<AttachmentListDto>.CreateAsync(_attachmentService.GetList(id), page));
        }

        [HttpGet]
        [ActionInfo(IconType = IconType.FontAwesome5, Icon = "fas fa-plus", Name = nameof(Resource.Resource.Add), order = 2)]
        public IActionResult Create(Guid id)
        {
            return View(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid relatedId, IFormFileCollection Photo)
        {
            await _attachmentService.AddList(relatedId, Photo);
            return RedirectToAction(nameof(Index), new { id = relatedId });
        }

        [HttpGet]
        public async Task<IActionResult> Remove(Guid id)
        {
            var relateId = _attachmentService.Get(id).RelateId;
            //if (_attachmentService.Delete(id).DeleteStatus == DeleteStatus.Successfully)
            await _attachmentService.RemoveImage(id, relateId);

            return RedirectToAction(nameof(PreView), new { id = relateId });
        }
    }
}