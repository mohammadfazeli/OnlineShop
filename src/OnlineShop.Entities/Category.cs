using OnlineShop.Entities.Entities.Area.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Entities
{
    public class Category : BaseEntity
    {

        public Category()
        {
            Products = new HashSet<Product>();
            //Id = Guid.NewGuid();
        }


        public string Name { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}