using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.categories.Category
{
    public class CategoryDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.CategoryGroup),ResourceType = typeof(Resource.Resource))]
        public Guid CategoryGroupId { get; set; }

        public DropDownViewModel CategoryGroupDropDown { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public DropDownViewModel ParentCategoryDropDown { get; set; }
    }
}