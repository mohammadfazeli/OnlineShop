using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Areas.Identity.Controllers;
using OnlineShop.Web.Classes;

namespace OnlineShop.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string area)
        {
            Assembly asm = Assembly.GetAssembly(typeof(BaseController));

            var asd = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(MenuAttribute), true).Any())
                .Select(x => new
                {
                    Area = area,
                    Controller = x.DeclaringType.Name.Replace("Controller", ""),
                    Action = x.Name,
                    Contrller = x.DeclaringType
                })
                .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            var menu = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type =>
                    type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(MenuAttribute), true).Any())
                .Select(x => new Menu()
                {
                    ControllerName = Resource.Resource.ResourceManager.GetString(x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.Name).FirstOrDefault())
                    ,
                    ControllerIconType = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.IconType)
                        .FirstOrDefault(),
                    ControllerIcon = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.Icon)
                        .FirstOrDefault(),
                    ControllerOrder = x.DeclaringType.GetCustomAttributes<MenuAttribute>().Select(s => s.order)
                        .FirstOrDefault(),
                    Area = area,
                    Controller = x.DeclaringType.Name.Replace("Controller", ""),

                    menuItems = new List<MenuItem>()
                    {
                        new MenuItem()
                        {
                            Action = x.Name,

                            ActionName =  Resource.Resource.ResourceManager.GetString(x.GetCustomAttributes<MenuAttribute>().Select(s => s.Name).FirstOrDefault()),

                            ActionIconType = x.GetCustomAttributes<MenuAttribute>().Select(s => s.IconType)
                                .FirstOrDefault(),

                            ActionIcon = x.GetCustomAttributes<MenuAttribute>().Select(s => s.Icon).FirstOrDefault(),

                            ActionOrder = x.GetCustomAttributes<MenuAttribute>().Select(s => s.order).FirstOrDefault(),
                        }
                    }
                });

            var finalMenus = menu.GroupBy(g => new
            {
                g.ControllerName,
                g.ControllerIconType,
                g.ControllerOrder,
                g.ControllerIcon,
                g.Area,
                g.Controller
            }).Select(s => new Menu()
            {
                ControllerName = s.Key.ControllerName,
                ControllerIconType = s.Key.ControllerIconType,
                ControllerOrder = s.Key.ControllerOrder,
                ControllerIcon = s.Key.ControllerIcon,
                Area = s.Key.Area,
                Controller = s.Key.Controller,
                menuItems = s.SelectMany(f => f.menuItems).ToList()
            });

            return View(finalMenus);
        }
    }
}