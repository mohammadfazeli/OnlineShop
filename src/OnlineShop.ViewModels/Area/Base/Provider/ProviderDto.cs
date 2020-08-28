using OnlineShop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Provider
{
    public class ProviderDto : BaseDto
    {
        [Required(ErrorMessage = "(*)")]
        [Display(Name = nameof(Resource.Resource.ProviderName), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.Addrss), ResourceType = typeof(Resource.Resource))]
        public string Addrss { get; set; }

        [Display(Name = nameof(Resource.Resource.Tel), ResourceType = typeof(Resource.Resource))]
        public string Tel { get; set; }

        [Display(Name = nameof(Resource.Resource.Mobile), ResourceType = typeof(Resource.Resource))]
        [RegularExpression(@"^(\+98|0)?9\d{9}$",
            ErrorMessageResourceName = nameof(Resource.Resource.InValidMobileNumber), ErrorMessageResourceType = typeof(Resource.Resource))]
        public string Mobile { get; set; }

        [Display(Name = nameof(Resource.Resource.Fax), ResourceType = typeof(Resource.Resource))]
        public string Fax { get; set; }

        [Display(Name = nameof(Resource.Resource.ManagerName), ResourceType = typeof(Resource.Resource))]
        public string ManagerName { get; set; }
    }
}