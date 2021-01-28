using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutListFullInfoDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup),ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode),ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider),ResourceType = typeof(Resource.Resource))]
        public string ProviderName { get; set; }

        [Display(Name = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public string ModelName { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice),ResourceType = typeof(Resource.Resource))]
        public string Price { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice),ResourceType = typeof(Resource.Resource))]
        public string OldPrice { get; set; }
    }
}