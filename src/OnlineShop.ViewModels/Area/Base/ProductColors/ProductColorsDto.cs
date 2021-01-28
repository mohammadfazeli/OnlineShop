using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductColors
{
    public class ProductColorsDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public Guid? ColorId { get; set; }

        public DropDownViewModel ColorDropDown { get; set; }
    }
}