using DNTPersianUtils.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Coupon
{
    public class CouponDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.PercentDiscount),ResourceType = typeof(Resource.Resource))]
        public int PercentDiscount { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        public DateTime? FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        public string strFromDate => FromDate?.ToShortPersianDateString();

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.ToDate),ResourceType = typeof(Resource.Resource))]
        public DateTime? ToDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate),Prompt = nameof(Resource.Resource.FromDate),ResourceType = typeof(Resource.Resource))]
        public string strToDate => ToDate?.ToShortPersianDateString();
    }
}