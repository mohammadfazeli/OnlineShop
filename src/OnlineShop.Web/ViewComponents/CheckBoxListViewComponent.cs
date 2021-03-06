using Microsoft.AspNetCore.Mvc;
using OnlineShop.ViewModels.Base;

namespace OnlineShop.Web.ViewComponents
{
    public class CheckBoxListViewComponent:ViewComponent
    {
        public CheckBoxListViewComponent()
        {
        }

        public IViewComponentResult Invoke(CheckBoxListViewModel checkBoxList)
        {
            return View(checkBoxList);
        }
    }
}