using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Area.Base.categories.Category
{
    public class CategoryListDto:BaseDto
    {
        [Display(Name = nameof(Resource.Resource.CategoryGroup),ResourceType = typeof(Resource.Resource))]
        public string CategoryGroupName { get; set; }

        [Display(Name = nameof(Resource.Resource.Name),ResourceType = typeof(Resource.Resource))]
        public string Name { get; set; }

        [Display(Name = nameof(Resource.Resource.ForeignName),ResourceType = typeof(Resource.Resource))]
        public string ForeignName { get; set; }

        [Display(Name = nameof(Resource.Resource.ParentCategory),ResourceType = typeof(Resource.Resource))]
        public string ParentCategoryName { get; set; }
    }
}