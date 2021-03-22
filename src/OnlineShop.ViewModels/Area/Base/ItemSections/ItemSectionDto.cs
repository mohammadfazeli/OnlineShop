using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ItemSections
{
    public class ItemSectionDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        public Guid? ProductId { get; set; }

        public DropDownViewModel ProductDropDown { get; set; }

        [Display(Name = nameof(Resource.Resource.Section),Prompt = nameof(Resource.Resource.Section),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public Guid SectionId { get; set; }

        public DropDownViewModel SectionDropDown { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public DateTime? FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public DateTime? ToDate { get; set; }
    }
}