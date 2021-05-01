using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Category:BaseEntity
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        [ForeignKey(nameof(CategoryGroupId))]
        public virtual CategoryGroup CategoryGroup { get; set; }

        public Guid CategoryGroupId { get; set; }
        public string Name { get; set; }
        public string ForeignName { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public virtual Category ParentCategory { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}