using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductDetails

{
    public class ProductDetailListDto : BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.Color), ResourceType = typeof(Resource.Resource))]
        public string ColorName { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider), ResourceType = typeof(Resource.Resource))]
        public string ProviderName { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        public string ModelName { get; set; }
    }
}