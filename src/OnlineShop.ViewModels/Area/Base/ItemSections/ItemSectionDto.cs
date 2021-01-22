using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ItemSections
{
<<<<<<< HEAD
    public class ItemSectionDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        public Guid? ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.ItemSectionType),Prompt = nameof(Resource.Resource.ItemSectionType),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public ItemSectionType ItemSectionType { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        [Required(ErrorMessage = "(*)")]
        public DateTime? FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
=======
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
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        [Required(ErrorMessage = "(*)")]
        public DateTime? ToDate { get; set; }
    }
}