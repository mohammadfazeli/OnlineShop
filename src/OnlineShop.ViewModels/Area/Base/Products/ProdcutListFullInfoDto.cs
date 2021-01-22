<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;

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
        public decimal Price { get; set; }

        [Display(Name = nameof(Resource.Resource.OldPrice),ResourceType = typeof(Resource.Resource))]
        public decimal OldPrice { get; set; }
=======
﻿using DNTPersianUtils.Core;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ProdcutListFullInfoDto : BaseDto
    {
        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup), ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.UserCode), ResourceType = typeof(Resource.Resource))]
        public string UserCode { get; set; }

        [Display(Name = nameof(Resource.Resource.Color), ResourceType = typeof(Resource.Resource))]
        public string ColorName { get; set; }

        [Display(Name = nameof(Resource.Resource.Provider), ResourceType = typeof(Resource.Resource))]
        public string ProviderName { get; set; }

        [Display(Name = nameof(Resource.Resource.Model), ResourceType = typeof(Resource.Resource))]
        public string ModelName { get; set; }

        [Display(Name = nameof(Resource.Resource.NewPrice), ResourceType = typeof(Resource.Resource))]
        public decimal PricePrice { get; set; }
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
    }
}