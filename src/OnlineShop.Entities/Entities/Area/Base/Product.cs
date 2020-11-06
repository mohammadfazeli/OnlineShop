﻿using OnlineShop.Entities.AuditableEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
            ProductDetails = new HashSet<ProductDetail>();
        }

        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string UserCode { get; set; }

        public Guid? ProductGroupId { get; set; }

        [ForeignKey(nameof(ProductGroupId))]
        public virtual ProductGroup ProductGroup { get; set; }

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}