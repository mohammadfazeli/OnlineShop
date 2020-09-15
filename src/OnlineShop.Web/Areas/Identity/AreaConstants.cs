using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2550
    /// </summary>
    public static class AreaConstants
    {
        public const string IdentityArea = "Identity";
        public const string Base = "Base";

        public enum Area
        {
            [Display(Name = "ادمین")]
            IdentityArea = 1,

            [Display(Name = "اطلاعات پایه")]
            Base = 2
        }
    }
}