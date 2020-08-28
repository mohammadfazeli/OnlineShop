using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutDto : BaseDto
    {
        public const string AllowedImages = ".png,.jpg,.jpeg,.gif";

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.ProductGroup), ResourceType = typeof(Resource.Resource))]
        public Guid? ProductGroupId { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName), ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }

        [Display(Name = "تصویر")]
        [StringLength(maximumLength: 1000, ErrorMessage = "حداکثر طول آدرس تصویر 1000 حرف است.")]
        public string PhotoFileName { set; get; }

        [UploadFileExtensions(AllowedImages,
            ErrorMessage = "لطفا تنها یک تصویر " + AllowedImages + " را ارسال نمائید.")]
        [DataType(DataType.Upload)]
        public IFormFileCollection Photo { get; set; }
    }
}