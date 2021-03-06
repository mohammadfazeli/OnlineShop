using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProductSearchShop:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Color),Prompt = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public List<SelectListItem> ColorList { get; set; }

        [Display(Name = nameof(Resource.Resource.Model),Prompt = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public List<SelectListItem> ModelList { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider),Prompt = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public List<SelectListItem> ProviderList { get; set; }

        [Display(Name = nameof(Resource.Resource.Size),Prompt = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public List<SelectListItem> SizeList { get; set; }
    }
}