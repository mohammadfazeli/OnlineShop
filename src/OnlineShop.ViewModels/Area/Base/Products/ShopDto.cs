using OnlineShop.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.Products
{
    public class ShopDto:BaseDto
    {
        public PaginatedList<ProdcutItemDto> ProdcutItems { get; set; }

        [Display(Name = nameof(Resource.Resource.Color),Prompt = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public CheckBoxListViewModel ColorCheckBoxList { get; set; }

        [Display(Name = nameof(Resource.Resource.ProductGroup),Prompt = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public CheckBoxListViewModel ProductGroupCheckBoxList { get; set; }

        [Display(Name = nameof(Resource.Resource.Size),Prompt = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public CheckBoxListViewModel SizeCheckBoxList { get; set; }

        [Display(Name = nameof(Resource.Resource.Model),Prompt = nameof(Resource.Resource.Color),ResourceType = typeof(Resource.Resource))]
        public CheckBoxListViewModel ModelCheckBoxList { get; set; }

        public bool IsFilterPrice { get; set; }
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}