using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutItemDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup),ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode),ResourceType = typeof(Resource.Resource))]
        public string ProductUserCode { get; set; }

        [Display(Name = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public string ModelName { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider),ResourceType = typeof(Resource.Resource))]
        public string Provider { get; set; }

        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
    }
}