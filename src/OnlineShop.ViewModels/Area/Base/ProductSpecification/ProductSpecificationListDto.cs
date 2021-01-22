using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSpecification
{
    public class ProductSpecificationListDto:BaseDto
    {
        public Guid ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.SpecificationName),Prompt = nameof(Resource.Resource.SpecificationName),ResourceType = typeof(Resource.Resource))]
        public string SpecificationName { get; set; }

        [Display(Name = nameof(Resource.Resource.SpecificationType),Prompt = nameof(Resource.Resource.SpecificationType),ResourceType = typeof(Resource.Resource))]
        public SpecificationType SpecificationType { get; set; }

        [Display(Name = nameof(Resource.Resource.SpecificationValue),Prompt = nameof(Resource.Resource.SpecificationValue),ResourceType = typeof(Resource.Resource))]
        public string SpecificationValue { get; set; }

<<<<<<< HEAD
        [Display(Name = nameof(Resource.Resource.SortOrder),Prompt = nameof(Resource.Resource.SortOrder),ResourceType = typeof(Resource.Resource))]
=======
        [Display(Name = nameof(Resource.Resource.SortOrder), Prompt = nameof(Resource.Resource.SortOrder), ResourceType = typeof(Resource.Resource))]
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        public int SortOrder { get; set; }
    }
}