using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Contracts.Area.Base;
using OnlineShop.ViewModels.Area.Base.Section;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class SectionsViewComponent:ViewComponent
    {
        private readonly ISectionService _sectionService;

        public SectionsViewComponent(ISectionService sectionService) => _sectionService = sectionService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SectionDetailListDro> items = await _sectionService.GetSections();
            return View(items);
        }
    }
}