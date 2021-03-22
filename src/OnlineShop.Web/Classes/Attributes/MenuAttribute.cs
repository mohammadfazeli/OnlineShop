using OnlineShop.Common.Enums;
using System;

namespace OnlineShop.Web.Classes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MenuAttribute:Attribute, ICustomAttribute
    {
        public MenuAttribute()
        {
        }

        public MenuGroupEnum MenuGroup { get; set; }
        public string Icon { get; set; }
        public IconType IconType { get; set; }
        public string Name { get; set; }
        public int order { get; set; }
    }
}