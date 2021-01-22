using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductRelated : BaseEntity
    {
        public ProductRelated()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid? RelatedProductId { get; set; }

        [ForeignKey(nameof(RelatedProductId))]
        public virtual Product RelatedProduct { get; set; }
    }
}