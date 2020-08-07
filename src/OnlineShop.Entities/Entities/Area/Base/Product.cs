using OnlineShop.Entities.AuditableEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string UserCode { get; set; }

        public Guid? ProductGroupId { get; set; }
        [ForeignKey(nameof(ProductGroupId))]
        public virtual ProductGroup  ProductGroup { get; set; }

    }
}