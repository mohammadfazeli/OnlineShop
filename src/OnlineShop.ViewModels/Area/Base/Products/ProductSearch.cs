using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProductSearch : BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name), Prompt = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), Prompt = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }

        public Guid? ModelId { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), Prompt = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        public DropDownViewModel ModelName { get; set; }
    }
}