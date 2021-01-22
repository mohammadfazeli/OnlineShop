using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSalePrice

{
    public class ProductSalePriceListDto:BaseDto
    {
        public Guid? ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice),ResourceType = typeof(Resource.Resource))]
        public string OldPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice),ResourceType = typeof(Resource.Resource))]
        public string NewPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        public string FromDate { get; set; }
    }
}