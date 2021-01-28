using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductColors

{
    public class ProductColorsListDto:BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public string ColorName { get; set; }
    }
}