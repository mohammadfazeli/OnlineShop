using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductDetails
{
    public class ProductDetailDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Display(Name = nameof(Resource.Resource.Color), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ColorId { get; set; }

        public DropDownViewModel ColorDropDown { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ProviderId { get; set; }

        public DropDownViewModel ProviderDropDown { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ModelId { get; set; }

        public DropDownViewModel ModelDropDown { get; set; }
    }
}