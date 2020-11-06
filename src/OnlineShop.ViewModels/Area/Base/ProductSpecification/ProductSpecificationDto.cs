using OnlineShop.Common.Enums;
using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSpecification
{
    public class ProductSpecificationDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product), Prompt = nameof(Resource.Resource.Product), ResourceType = typeof(Resource.Resource))]
        public Guid ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.SpecificationName), Prompt = nameof(Resource.Resource.SpecificationName), ResourceType = typeof(Resource.Resource))]
        public string SpecificationName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.SpecificationType), Prompt = nameof(Resource.Resource.SpecificationType), ResourceType = typeof(Resource.Resource))]
        public SpecificationType SpecificationType { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.SpecificationValue), Prompt = nameof(Resource.Resource.SpecificationValue), ResourceType = typeof(Resource.Resource))]
        public string SpecificationValue { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.SortOrder), Prompt = nameof(Resource.Resource.SortOrder), ResourceType = typeof(Resource.Resource))]
        [RegularExpression(@"[0-9]*", ErrorMessageResourceName = nameof(Resource.Resource.InputMustBeNumber)
            , ErrorMessageResourceType = typeof(Resource.Resource))]
        public int SortOrder { get; set; }
    }
}