using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD:src/OnlineShop.Web/Areas/Admin/ViewComponents/MenuViewComponent.cs
using OnlineShop.Services.Contracts.Admin;
=======
using OnlineShop.Services.Contracts.Identity;
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2:src/OnlineShop.Web/ViewComponents/MenuViewComponent.cs
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Areas.Admin.Controllers;
using OnlineShop.Web.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

<<<<<<< HEAD:src/OnlineShop.Web/Areas/Admin/ViewComponents/MenuViewComponent.cs
namespace OnlineShop.Areas.Admin.ViewComponents
=======
namespace OnlineShop.Areas.Identity.ViewComponents
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2:src/OnlineShop.Web/ViewComponents/MenuViewComponent.cs
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ISecurityTrimmingService _securityTrimmingService;

        public MenuViewComponent(ISecurityTrimmingService securityTrimmingService)
        {
            _securityTrimmingService = securityTrimmingService;
        }

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
            //.Where(x => _securityTrimmingService.CanCurrentUserAccess(x.Area, x.Controller, x.menuItems.Select(s => s.Action).FirstOrDefault()));

            return View(finalMenus);
        }
    }
}