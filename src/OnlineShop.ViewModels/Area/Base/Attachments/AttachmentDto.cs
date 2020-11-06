using Microsoft.AspNetCore.Http;
using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Attachments
{
    public class AttachmentDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        public Guid RelateId { get; set; }

        [Display(Name = "نوع فایل ضمیمه")]
        public AttachmentType Type { get; set; }

        public string ExtentionFile { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }
    }
}