using System.Collections.Generic;
using OnlineShop.Common.Enum;

namespace OnlineShop.ViewModels.Base
{
    public class MenuViewModel
    {

        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public IconType ControllerIconType { get; set; }
        public string ControllerIcon { get; set; }

        public IconType ActionIconType { get; set; }
        public string ActionIcon { get; set; }

        public int ControllerOrder { get; set; }
        public int ActionOrder { get; set; }
    }



    public class Menu
    {
      
        public string ControllerName { get; set; }
        public IconType ControllerIconType { get; set; }
        public string ControllerIcon { get; set; }
        public int ControllerOrder { get; set; }
        public List<MenuItem> menuItems { get; set; }
    }
    public class MenuItem
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ActionName { get; set; }
        public IconType ActionIconType { get; set; }
        public string ActionIcon { get; set; }
        public int ActionOrder { get; set; }
    }
}
