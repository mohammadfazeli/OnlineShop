using OnlineShop.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.categories.CategoryGroup
{
    public class CategoryGroupDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }
    }
}