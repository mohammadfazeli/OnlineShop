using OnlineShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.Base
{
    public class ProductCommnet : BaseEntity
    {
        public ProductCommnet()
        {
        }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public string Commnet { get; set; }

        public Guid? ParentProductCommnetId { get; set; }

        [ForeignKey(nameof(ParentProductCommnetId))]
        public virtual ProductCommnet ParentProductCommnet { get; set; }

        public virtual ICollection<ProductCommnet> ReplayProductCommnet { get; set; }
    }
}