using OnlineShop.Entities.Entities.Area.WareHouse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Product:BaseEntity
    {
        public Product()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
            ProductTags = new HashSet<ProductTags>();
            RelatedProducts = new HashSet<ProductRelated>();
            Relateds = new HashSet<ProductRelated>();
            ProductColors = new HashSet<ProductColor>();
            ProductCommnets = new HashSet<ProductCommnet>();
            ProductModels = new HashSet<ProductModel>();
            ProductSizes = new HashSet<ProductSize>();
            ExitDetails = new HashSet<ExitDetail>();
            ProductRequestDetails = new HashSet<ProductRequestDetail>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string UserCode { get; set; }
        public Guid? ProductGroupId { get; set; }

        [ForeignKey(nameof(ProductGroupId))]
        public virtual ProductGroup ProductGroup { get; set; }

        public Guid? ProviderId { get; set; }

        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider { get; set; }

        public Guid? ModelId { get; set; }

        [ForeignKey(nameof(ModelId))]
        public virtual Model Model { get; set; }

        public Guid? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [InverseProperty(nameof(ProductRelated.Product))]
        public virtual ICollection<ProductRelated> RelatedProducts { get; set; }

        [InverseProperty(nameof(ProductRelated.RelatedProduct))]
        public virtual ICollection<ProductRelated> Relateds { get; set; }

        public virtual ICollection<ProductCommnet> ProductCommnets { get; set; }
        public virtual ICollection<ProductSalePrice> ProductSalePrices { get; set; }
        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public virtual ICollection<ItemSection> ItemSections { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<ExitDetail> ExitDetails { get; set; }
        public virtual ICollection<ProductRequestDetail> ProductRequestDetails { get; set; }
    }
}