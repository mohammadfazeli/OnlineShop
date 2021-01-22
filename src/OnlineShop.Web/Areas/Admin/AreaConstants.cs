using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2550
    /// </summary>
    public static class AreaConstants
    {
        public const string AdminArea = "Admin";
        public const string Base = "Base";

        public enum Area
        {
            [Display(Name = "ادمین")]
            AdminArea = 1,

            [Display(Name = "اطلاعات پایه")]
            Base = 2
        }
    }
}