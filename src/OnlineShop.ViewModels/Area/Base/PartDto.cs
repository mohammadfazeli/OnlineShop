using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base
{
    public class PartDto : BaseDto
    {

        [Required(ErrorMessage = "(*)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.Title), ResourceType = typeof(Resource.Resource))]
        public string Title { get; set; }

        [Display(Name = nameof(Resource.Resource.FullInfo), ResourceType = typeof(Resource.Resource))]
        public string FullInfo { get; set; }

    }
}
