using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class CategoryGroup:BaseEntity
    {
        public CategoryGroup()
        {
            Categories = new HashSet<Category>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}