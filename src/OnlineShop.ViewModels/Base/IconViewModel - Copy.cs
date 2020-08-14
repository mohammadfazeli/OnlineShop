using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OnlineShop.Common.Enum;

namespace OnlineShop.ViewModels.Base
{
    public class DropDownViewModel
    {
        public string value { get; set; }
        public string Text { get; set; }
    }

    public class DropDwon
    {
        public SelectTagHelper MyProperty { get; set; }
    }
}