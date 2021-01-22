using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductRelated
{
    public class ProductRelatedDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public Guid? RelatedProductId { get; set; }

        public DropDownViewModel RelatedProductDropDown { get; set; }
    }
}