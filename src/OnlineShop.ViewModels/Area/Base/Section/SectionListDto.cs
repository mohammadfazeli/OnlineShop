using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Section
{
    public class SectionListDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.SectionName),Prompt = nameof(Resource.Resource.SectionName),ResourceType = typeof(Resource.Resource))]
        public string SectionName { get; set; }
    }
}