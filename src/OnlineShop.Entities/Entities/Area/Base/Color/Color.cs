using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Color:BaseEntity
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string UserCode { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}