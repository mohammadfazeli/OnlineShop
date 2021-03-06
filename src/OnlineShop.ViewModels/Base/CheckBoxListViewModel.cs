using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace OnlineShop.ViewModels.Base
{
    public class CheckBoxListViewModel
    {
        public string Name { get; set; }
        public string CheckBoxName { get; set; }
        public SelectList Items { get; set; }
        public List<Guid> SelectedIds { get; set; }
    }
}