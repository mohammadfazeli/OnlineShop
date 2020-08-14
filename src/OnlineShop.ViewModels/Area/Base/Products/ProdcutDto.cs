using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.ProductGroup), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductGroupId { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName), ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }
    }
}