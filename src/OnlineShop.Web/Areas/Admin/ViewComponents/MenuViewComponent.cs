using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Services.Contracts.Admin;
using OnlineShop.ViewModels.Base;
using OnlineShop.Web.Areas.Admin.Controllers;
using OnlineShop.Web.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMemoryCache _cacheHelper;

        public MenuViewComponent(IMemoryCache cacheHelper)
        {
            _cacheHelper = cacheHelper;
        }

        public IViewComponentResult Invoke(string area)
        {
            //IEnumerable<Menu> menus = _cacheHelper.GetOrCreateAsync(
            //$"_Menus{area}",
            //    entry =>
            //    {
            //        entry.SetSize(1000);
            //        return Task.FromResult(GetMenus(area));
            //    });
            var menus = GetMenus(area);
            return View(menus);
        }

        private IEnumerable<Menu> GetMenus(string area)
        {
            Assembly asm = Assembly.GetAssembly(typeof(BaseController));
            var menu = asm.GetTypes()
                .Where(type => typeof(BaseController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
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
            return finalMenus;
        }
    }
}