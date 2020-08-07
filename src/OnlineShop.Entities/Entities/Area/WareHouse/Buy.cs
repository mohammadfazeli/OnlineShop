using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineShop.Entities.Entities.Area.Base;
using OnlineShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class Buy : BaseEntity
    {

        public Buy()
        {
            BuyDetails = new HashSet<BuyDetail>();
        }
        public DateTime BuyDate { get; set; }


        public int RegisterUserId { get; set; }
        [ForeignKey(nameof(RegisterUserId))]
        public virtual User RegisterUser { get; set; }

        public Guid? ProviderId { get; set; }
        [ForeignKey(nameof(ProviderId))]
        public virtual Provider Provider { get; set; }

        public virtual ICollection<BuyDetail> BuyDetails { get; set; }

    }

}
