using DNTBreadCrumb.Core;
using DNTCommon.Web.Core;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OnlineShop.Common.AdminToolkit;
using OnlineShop.Entities.Identity;
using OnlineShop.Services.Contracts.Admin;
using OnlineShop.Services.Admin;
using OnlineShop.ViewModels.Admin;
using OnlineShop.ViewModels.Admin.Emails;
using OnlineShop.ViewModels.Admin.Settings;
using System;
using System.Threading.Tasks;
using OnlineShop.Areas.Admin;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = ConstantRoles.Admin)]
    [Area(AreaConstants.AdminArea)]
    [BreadCrumb(Title = "تغییر کلمه‌ی عبور كاربر توسط مدير سيستم",UseDefaultRouteUrl = true,Order = 0)]
    public class ChangeUserPasswordController:BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IApplicationUserManager _userManager;
        private readonly IApplicationSignInManager _signInManager;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IUsedPasswordsService _usedPasswordsService;
        private readonly IOptionsSnapshot<SiteSettings> _siteOptions;

        public ChangeUserPasswordController(
            IApplicationUserManager userManager,
            IApplicationSignInManager signInManager,
            IEmailSender emailSender,
            IPasswordValidator<User> passwordValidator,
            IUsedPasswordsService usedPasswordsService,
            IOptionsSnapshot<SiteSettings> siteOptions)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(_signInManager));
            _passwordValidator = passwordValidator ?? throw new ArgumentNullException(nameof(_passwordValidator));
            _usedPasswordsService = usedPasswordsService ?? throw new ArgumentNullException(nameof(_usedPasswordsService));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(_emailSender));
            _siteOptions = siteOptions ?? throw new ArgumentNullException(nameof(_siteOptions));
        }

        [BreadCrumb(Title = "ایندکس",Order = 1)]
        public async Task<IActionResult> Index(int? id)
        {
            if(!id.HasValue)
            {
                return View("NotFound");
            }

            var user = await _userManager.FindByIdAsync(id.Value.ToString());
            if(user == null)
            {
                return View("NotFound");
            }

            return View(model: new ChangeUserPasswordViewModel
            {
                UserId = user.Id,
                Name = user.UserName
            });
        }

        /// <summary>
        /// For [Remote] validation
        /// </summary>
        [AjaxOnly, HttpPost, ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None,NoStore = true)]
        public async Task<IActionResult> ValidatePassword(string newPassword,int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _passwordValidator.ValidateAsync(
                (UserManager<User>)_userManager,user,newPassword);
            return Json(result.Succeeded ? "true" : result.DumpErrors(useHtmlNewLine: true));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ChangeUserPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if(user == null)
            {
                return View("NotFound");
            }

            var result = await _userManager.UpdatePasswordHash(user,model.NewPassword,validatePassword: true);
            if(result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);

                // reflect the changes in the Identity cookie
                await _signInManager.RefreshSignInAsync(user);

                await _emailSender.SendEmailAsync(
                           email: user.Email,
                           subject: "اطلاع رسانی تغییر کلمه‌ی عبور",
                           viewNameOrPath: "~/Areas/Admin/Views/EmailTemplates/_ChangePasswordNotification.cshtml",
                           model: new ChangePasswordNotificationViewModel
                           {
                               User = user,
                               EmailSignature = _siteOptions.Value.Smtp.FromName,
                               MessageDateTime = DateTime.UtcNow.ToLongPersianDateTimeString()
                           });

                return RedirectToAction(nameof(Index),"UserCard",routeValues: new { id = user.Id });
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty,error.Description);
            }

            return View(model);
        }
    }
}