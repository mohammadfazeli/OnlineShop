using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Section
{
    public class SectionDto:BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.SectionName),Prompt = nameof(Resource.Resource.SectionName),ResourceType = typeof(Resource.Resource))]
        public string SectionName { get; set; }
    }
}