using DNTPersianUtils.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductPriceModificatin

{
    public class ProductPriceModificatinListDto : BaseDto
    {
        public Guid? ProductDetailId { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice), ResourceType = typeof(Resource.Resource))]
        public decimal OldPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice), ResourceType = typeof(Resource.Resource))]
        public decimal NewPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public DateTime FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public string strFromDate => FromDate.ToShortPersianDateString();
    }
}