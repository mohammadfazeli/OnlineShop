using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace OnlineShop.ViewModels.Base
{
    public class DropDownViewModel
    {
        public Guid? id { get; set; }
        public SelectList SelectList { get; set; }
        public ICollection<string> CurrentValues { get; set; }
    }
}