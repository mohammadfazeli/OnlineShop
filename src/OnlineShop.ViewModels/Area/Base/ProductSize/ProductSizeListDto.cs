using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSizes

{
    public class ProductSizeListDto:BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.Size),ResourceType = typeof(Resource.Resource))]
        public string SizeName { get; set; }
    }
}