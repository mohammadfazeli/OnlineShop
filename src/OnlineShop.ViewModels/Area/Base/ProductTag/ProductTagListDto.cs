using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductTag

{
    public class ProductTagListDto:BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.Tag),ResourceType = typeof(Resource.Resource))]
        public string TagName { get; set; }
    }
}