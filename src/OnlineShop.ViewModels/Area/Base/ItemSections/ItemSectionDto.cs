using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ItemSections
{
    public class ItemSectionDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        public Guid? ProductDetailId { get; set; }

        [Display(Name = nameof(Resource.Resource.ItemSectionType), Prompt = nameof(Resource.Resource.ItemSectionType), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public ItemSectionType ItemSectionType { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public DateTime? FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public DateTime? ToDate { get; set; }
    }
}