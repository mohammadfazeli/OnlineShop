using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ItemSections
{
    public class OrderDto:BaseDto
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

        public int OrderNo { get; set; }
        public int RegisterUserId { get; set; }
        public Guid? CouponId { get; set; }
        public decimal Sum { get; set; }
        public decimal EndFee { get; set; }
        public bool Lock { get; set; }
        public bool IsPayment { get; set; }
        public string PaymentResult { get; set; }
        public int FactorNo { get; set; }
        public string BankFollowupNo { get; set; }
    }
}