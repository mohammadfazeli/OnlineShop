using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Entities.Entities.Area.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class ProductRequestDetail : BaseEntity
    {

        public ProductRequestDetail()
        {
        }

        public Guid? ProductRequestId { get; set; }
        [ForeignKey(nameof(ProductRequestId))]
        public virtual ProductRequest ProductRequest { get; set; }

        public Guid? ProductDetailId { get; set; }
        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail ProductDetail { get; set; }

        public int Number { get; set; }
        public int? ApprovedNumber { get; set; }


    }

}
