using System;
using System.Collections.Generic;

namespace OnlineShop.ViewModels.Area.Base.categories
{
    public class CategoryGeneralDto:BaseDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public List<CategoryDetailDto> SubCategories { get; set; }
    }

    public class CategoryDetailDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public List<CategoryDetailDto> SubCategories { get; set; }
    }
}