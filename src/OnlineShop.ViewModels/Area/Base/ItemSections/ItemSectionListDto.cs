using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.ItemSections
{
    public class ItemSectionListDto : BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Product), Prompt = nameof(Resource.Resource.ItemSectionType), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductId { get; set; }

        [Display(Name = nameof(Resource.Resource.Product), Prompt = nameof(Resource.Resource.ItemSectionType), ResourceType = typeof(Resource.Resource))]
        public string ProductName { get; set; }

        [Display(Name = nameof(Resource.Resource.ItemSectionType), Prompt = nameof(Resource.Resource.ItemSectionType), ResourceType = typeof(Resource.Resource))]
        public string ItemSectionType { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice), Prompt = nameof(Resource.Resource.NewPrice), ResourceType = typeof(Resource.Resource))]
        public string Price { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice), Prompt = nameof(Resource.Resource.OldPrice), ResourceType = typeof(Resource.Resource))]
        public string OldPrice { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public DateTime? FromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public string strFromDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public DateTime? ToDate { get; set; }

        [Display(Name = nameof(Resource.Resource.FromDate), Prompt = nameof(Resource.Resource.FromDate), ResourceType = typeof(Resource.Resource))]
        public string StrToDate { get; set; }
    }
}