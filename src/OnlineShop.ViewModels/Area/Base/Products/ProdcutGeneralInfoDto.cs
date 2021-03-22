using OnlineShop.ViewModels.Area.Base.Colors;
using OnlineShop.ViewModels.Area.Base.ProductSpecification;
using OnlineShop.ViewModels.Area.Base.ProductTag;
using OnlineShop.ViewModels.Area.Base.Sizes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutGeneralInfoDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.ProductGroup),ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

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
        public List<ColorstDto> ProductColors { get; set; }
        public List<SizeDto> ProductSizes { get; set; }
        public List<ProductTagListDto> ProductTags { get; set; }
        public List<ProductSpecificationListDto> ProductSpecifications { get; set; }
    }
}