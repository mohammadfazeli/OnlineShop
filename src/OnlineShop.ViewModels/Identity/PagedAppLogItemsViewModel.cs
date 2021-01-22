using System.Collections.Generic;
using OnlineShop.Entities.Identity;
using cloudscribe.Web.Pagination;

namespace OnlineShop.ViewModels.Admin
{
    public class PagedAppLogItemsViewModel
    {
        public PagedAppLogItemsViewModel()
        {
            Paging = new PaginationSettings();
        }

        public string LogLevel { get; set; } = string.Empty;

        public List<AppLogItem> AppLogItems { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}