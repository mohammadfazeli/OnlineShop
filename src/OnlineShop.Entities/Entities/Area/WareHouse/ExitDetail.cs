using OnlineShop.Entities.Entities.Area.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class ExitDetail:BaseEntity
    {
        public Guid? ExitId { get; set; }

        [ForeignKey(nameof(ExitId))]
        public virtual Exit Exit { get; set; }

        public Guid? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int? Number { get; set; }
    }
}