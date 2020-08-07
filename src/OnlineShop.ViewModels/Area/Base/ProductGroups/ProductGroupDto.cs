using OnlineShop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities.Entities.Area.Base.ProductGroups
{
    public class ProductGroupDto : BaseDto
    {

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]

        public string Name { get; set; }

    }
}