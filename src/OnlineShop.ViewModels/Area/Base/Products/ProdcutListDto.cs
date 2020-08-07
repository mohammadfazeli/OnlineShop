using OnlineShop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities.Entities.Area.Base.Products
{
    public class ProdcutListDto : BaseDto
    {

        [Display(Name = nameof(Resource.Resource.Name), ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }
        [Display(Name = nameof(Resource.Resource.ProductGroup), ResourceType = typeof(Resource.Resource))]
        public string ProductGroupName { get; set; }

    }
}