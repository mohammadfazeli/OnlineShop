using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using OnlineShop.Areas.Identity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Classes;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.Web.Areas.Identity.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult MenuBuilder(AreaConstants.Area area)
        {

            Assembly asm = Assembly.GetAssembly(typeof(BaseController));

            var controlleractionlist = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(MenuAttribute), true).Any())

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
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}