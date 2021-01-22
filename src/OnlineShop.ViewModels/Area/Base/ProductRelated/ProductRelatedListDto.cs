using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductRelated

{
    public class ProductRelatedListDto:BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        public Guid RelatedProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductRelated),ResourceType = typeof(Resource.Resource))]
        public string RelatedProductName { get; set; }
    }
}