using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSizes
{
    public class ProductSizesDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Size),ResourceType = typeof(Resource.Resource))]
        public Guid? SizeId { get; set; }

        public DropDownViewModel SizeDropDown { get; set; }
    }
}