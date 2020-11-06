using Microsoft.AspNetCore.Http;
using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Attachments
{
    public class AttachmentListDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        public Guid RelateId { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
        public string imageUrl { get; set; }
    }
}