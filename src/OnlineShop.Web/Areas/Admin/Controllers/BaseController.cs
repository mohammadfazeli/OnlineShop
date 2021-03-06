using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using NToastNotify;
using OnlineShop.Areas.Admin;
using OnlineShop.Common.Enums;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Classes;
using System;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Web.Areas.Admin.Controllers
{
    public class BaseController:Controller
    {
        public IActionResult MenuBuilder(AreaConstants.Area area)
        {
            Assembly asm = Assembly.GetAssembly(typeof(BaseController));

            var controlleractionlist = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(MenuAttribute),true).Any())

                .Select(x => new MenuViewModel()
                {
                    Area = area.ToString(),
                    Controller = x.DeclaringType.Name,
                    Action = x.Name,

                    ControllerName = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.Name).FirstOrDefault(),
                    ActionName = x.GetCustomAttributes<MenuAttribute>().Select(s => s.Name).FirstOrDefault(),

                    ControllerIconType = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.IconType).FirstOrDefault(),
                    ActionIconType = x.GetCustomAttributes<MenuAttribute>().Select(s => s.IconType).FirstOrDefault(),

                    ControllerIcon = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.Icon).FirstOrDefault(),
                    ActionIcon = x.GetCustomAttributes<MenuAttribute>().Select(s => s.Icon).FirstOrDefault(),
                })
                .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            return PartialView(controlleractionlist);
        }

        protected void PushAddMessage(IToastNotification _toastNotification,Common.ViewModel.CreateStatusvm result)
        {
            switch(result.CreateStatus)
            {
                case CreateStatus.Successfully:
                    _toastNotification.AddSuccessToastMessage(result.Message);
                    break;

                case CreateStatus.Fail:
                    _toastNotification.AddErrorToastMessage(result.Message);

                    break;

                case CreateStatus.Exists:
                    _toastNotification.AddWarningToastMessage(result.Message);
                    break;
            }
        }

        protected void PushUpdateMessage(IToastNotification _toastNotification,Common.ViewModel.UpdateStatusvm result)
        {
            switch(result.UpdateStatus)
            {
                case UpdateStatus.Successfully:
                    _toastNotification.AddSuccessToastMessage(result.Message);
                    break;

                case UpdateStatus.Fail:
                    _toastNotification.AddErrorToastMessage(result.Message);
                    break;

                case UpdateStatus.NotExists:
                    _toastNotification.AddAlertToastMessage(result.Message);
                    break;
            }
        }

        protected void PushDeleteMessage(IToastNotification _toastNotification,Common.ViewModel.DeleteStatusvm result)
        {
            switch(result.DeleteStatus)
            {
                case DeleteStatus.Successfully:
                    _toastNotification.AddSuccessToastMessage(result.Message);

                    break;

                case DeleteStatus.Fail:
                    _toastNotification.AddErrorToastMessage(result.Message);

                    break;

                case DeleteStatus.NotExists:
                    _toastNotification.AddWarningToastMessage(result.Message);

                    break;

                case DeleteStatus.Dependent:
                    _toastNotification.AddAlertToastMessage(result.Message);

                    break;

                default:
                    break;
            }
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}