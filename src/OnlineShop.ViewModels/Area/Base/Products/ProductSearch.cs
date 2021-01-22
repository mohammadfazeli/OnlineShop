using OnlineShop.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
<<<<<<< HEAD
    public class ProductSearch:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name),Prompt = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode),Prompt = nameof(Resource.Resource.UserCode),ResourceType = typeof(Resource.Resource))]
=======
    public class ProductSearch : BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name), Prompt = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), Prompt = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
        public string UserCode { get; set; }

        public Guid? ModelId { get; set; }

<<<<<<< HEAD
        [Display(Name = nameof(Resource.Resource.Model),Prompt = nameof(Resource.Resource.Model),ResourceType = typeof(Resource.Resource))]
        public DropDownViewModel ModelName { get; set; }

        public Guid? ProviderId { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider),Prompt = nameof(Resource.Resource.Provider),ResourceType = typeof(Resource.Resource))]
        public DropDownViewModel ProviderName { get; set; }
=======
        [Display(Name = nameof(Resource.Resource.Model), Prompt = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        public DropDownViewModel ModelName { get; set; }
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
    }
}