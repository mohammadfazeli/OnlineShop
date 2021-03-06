using OnlineShop.Entities.Entities.Area.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutGeneralInfoDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup),ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode),ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }

        [Display(Name = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public string ModelName { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider),ResourceType = typeof(Resource.Resource))]
        public string Provider { get; set; }

        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductTags> ProductTags { get; set; }
    }
}