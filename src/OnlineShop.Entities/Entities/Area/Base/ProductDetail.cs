using OnlineShop.Entities.Entities.Area.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductDetail : BaseEntity
    {
        public ProductDetail()
        {
            ProductPriceModificatins = new HashSet<ProductPriceModificatin>();
            ProductDetailSpecifications = new HashSet<ProductDetailSpecification>();
            BuyDetails = new HashSet<BuyDetail>();
            ExitDetails = new HashSet<ExitDetail>();
            ItemSections = new HashSet<ItemSection>();
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public Guid? ColorId { get; set; }

        [ForeignKey(nameof(ColorId))]
        public virtual Color Color { get; set; }

        public Guid? ProviderId { get; set; }

        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider { get; set; }

        public Guid? ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; }

        public virtual ICollection<ProductPriceModificatin> ProductPriceModificatins { get; set; }
        public virtual ICollection<ProductDetailSpecification> ProductDetailSpecifications { get; set; }
        public virtual ICollection<ItemSection> ItemSections { get; set; }

        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<ExitDetail> ExitDetails { get; set; }
    }
}