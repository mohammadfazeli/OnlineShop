using AspNetCore.Unobtrusive.Ajax;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OnlineShop.Common.IdentityToolkit;
using OnlineShop.Services.Services;
using OnlineShop.Web.Areas.Identity.Controllers;

namespace OnlineShop.Web.Controllers
{
    [BreadCrumb(Title = "خانه", UseDefaultRouteUrl = true, Order = 0)]
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        public IActionResult Index()
        {
            _toastNotification.AddSuccessToastMessage("Same for success message");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");

            //Info
            _toastNotification.AddInfoToastMessage();

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage();

            return View();
        }

        [BreadCrumb(Title = "خطا", Order = 1)]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// To test automatic challenge after redirecting from another site
        /// Sample URL: http://localhost:5000/Home/CallBackResult?token=1&status=2&orderId=3&terminalNo=4&rrn=5
        /// </summary>
        [Authorize]
        public IActionResult CallBackResult(long token, string status, string orderId, string terminalNo, string rrn)
        {
            var userId = User.Identity.GetUserId();
            return Json(new { userId, token, status, orderId, terminalNo, rrn });
        }

        [HttpPost]
        [AjaxOnly]
        public IActionResult AjaxMethod(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return SweetAlert("Oops!", "Please enter your name.", "warning");
            }
            _toastNotification.AddSuccessToastMessage("با موفقیت انجام شد.");

            return View();
        }

        private IActionResult SweetAlert(string title, string message, string type)
        {
            return Content($"swal ('{title}',  '{message}',  '{type}')", "text/javascript");
        }
    }
}