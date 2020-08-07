using OnlineShop.Entities.Entities.Area.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class ExitDetail : BaseEntity
    {


        public Guid? ExitId { get; set; }
        [ForeignKey(nameof(ExitId))]
        public virtual Exit Exit { get; set; }

        public Guid? ProductDetailId { get; set; }
        [ForeignKey(nameof(ProductDetailId))]
        public virtual ProductDetail  ProductDetail { get; set; }

        public int? Number { get; set; }

    }

}
