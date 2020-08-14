using OnlineShop.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductDetails
{
    public class ProductDetailDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Color), ResourceType = typeof(Resource.Resource))]
        public Guid? ColorId { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider), ResourceType = typeof(Resource.Resource))]
        public Guid? ProviderId { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        public Guid? ModelId { get; set; }
    }
}