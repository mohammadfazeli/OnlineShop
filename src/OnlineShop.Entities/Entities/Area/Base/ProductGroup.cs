using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductGroup : BaseEntity
    {
        public ProductGroup()
        {
            Products= new HashSet<Product>();
        }
        
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}