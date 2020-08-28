using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductDetails
{
    public class ProductDetailDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Color), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ColorId { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ProviderId { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid? ModelId { get; set; }
    }
}