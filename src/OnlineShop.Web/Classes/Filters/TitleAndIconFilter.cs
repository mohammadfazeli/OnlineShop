using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShop.Resource;
using OnlineShop.Web.Classes;
using System.Linq;

namespace KhabarTech.UI.Classes
{
    public class TitleAndIconFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ControllerActionDescriptor =
                filterContext.ActionDescriptor as ControllerActionDescriptor;

            var ActionInfoAtttribute =
                ControllerActionDescriptor.MethodInfo.GetCustomAttributes(
                    typeof(ICustomAttribute), false).FirstOrDefault() as ICustomAttribute;

            var controller = filterContext.Controller as Controller;
            if (controller == null) return;

            if (ActionInfoAtttribute != null)
            {
                controller.ViewData["title"] = Resource.ResourceManager.GetString(ActionInfoAtttribute.Name);
                controller.ViewData["Icon"] = ActionInfoAtttribute.Icon;
                controller.ViewData["IconType"] = ActionInfoAtttribute.IconType;
            }
        }
    }
}