using OnlineShop.Common.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductDetailSpecification : BaseEntity
    {
        public Guid? ProductDetailId { get; set; }

        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail ProductDetail { get; set; }

        public string SpecificationName { get; set; }
        public SpecificationType SpecificationType { get; set; }

        public string SpecificationValue { get; set; }
    }
}