using System.Collections.Generic;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Model:BaseEntity
    {
        public Model()
        {
            ProductModels = new HashSet<ProductModel>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string UserCode { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}