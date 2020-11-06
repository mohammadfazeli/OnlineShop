using OnlineShop.Common.Enums;
using System;

namespace OnlineShop.Web.Classes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ActionInfoAttribute : Attribute, ICustomAttribute
    {
        public ActionInfoAttribute()
        {

        }

        public string Icon { get; set ; }
        public IconType IconType { get; set; }
        public string Name { get; set; }
        public int order { get; set; }
    }
}
