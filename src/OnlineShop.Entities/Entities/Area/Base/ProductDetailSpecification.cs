using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductDetailSpecification  : BaseEntity
    {

        public Guid? ProductDetailId { get; set; }
        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail  ProductDetail { get; set; }

        public int? Weight { get; set; }
        public int? Length { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }


    }
}