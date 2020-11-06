using OnlineShop.Common.Enums;

namespace OnlineShop.Web.Classes
{
    public interface ICustomAttribute
    {
        string Icon { get; set; }
        IconType IconType { get; set; }
        string Name { get; set; }
        int order { get; set; }
    }
}