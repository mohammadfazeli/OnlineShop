using OnlineShop.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities.Entities.Area.Base.Products
{
    public class ProdcutDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]

        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup), ResourceType = typeof(Resource.Resource))]

        public Guid? ProductGroupId { get; set; }
    }
}