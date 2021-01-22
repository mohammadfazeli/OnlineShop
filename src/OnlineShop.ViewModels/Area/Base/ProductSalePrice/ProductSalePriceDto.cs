using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ProductSalePrice
{
    public class ProductSalePriceDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Product),Prompt = nameof(Resource.Resource.Product),ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice),Prompt = nameof(Resource.Resource.OldPrice),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"[0-9]*",ErrorMessageResourceName = nameof(Resource.Resource.InputMustBeNumber)
            ,ErrorMessageResourceType = typeof(Resource.Resource))]
        public decimal OldPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice),Prompt = nameof(Resource.Resource.NewPrice),ResourceType = typeof(Resource.Resource))]
        [DataType(DataType.Currency)]
        [RegularExpression(@"[0-9]*",ErrorMessageResourceName = nameof(Resource.Resource.InputMustBeNumber)
            ,ErrorMessageResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0.##}")]
        public decimal NewPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }
    }
}