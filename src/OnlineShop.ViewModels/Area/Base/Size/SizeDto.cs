using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Sizes
{
    public class SizeDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode),ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }
    }
}