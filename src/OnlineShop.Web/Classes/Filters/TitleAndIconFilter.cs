using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
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
                    typeof(ICustomAttribute), false).FirstOrDefault() as ActionInfoAttribute;


            var controller = filterContext.Controller as Controller;
            if (controller == null) return;

            if (ActionInfoAtttribute != null)
            {
                controller.ViewBag.Title = ActionInfoAtttribute.Name;
                controller.ViewBag.Icon = ActionInfoAtttribute.Icon;
                controller.ViewBag.IconType = ActionInfoAtttribute.IconType;
            }

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Log("OnResultExecuted", filterContext.RouteData);
        }
    }
}