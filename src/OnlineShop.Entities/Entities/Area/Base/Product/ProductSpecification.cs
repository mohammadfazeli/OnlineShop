using OnlineShop.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductSpecification:BaseEntity
    {
        public ProductSpecification()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public string SpecificationName { get; set; }
        public SpecificationType SpecificationType { get; set; }
        public string SpecificationValue { get; set; }
        public int SortOrder { get; set; }
    }
}