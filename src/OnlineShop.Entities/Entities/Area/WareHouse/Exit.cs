using OnlineShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class Exit : BaseEntity
    {

        public Exit()
        {
            ExitDetails = new HashSet<ExitDetail>();
        }
        public DateTime ExitDate { get; set; }

        public int RegisterUserId { get; set; }
        [ForeignKey(nameof(RegisterUserId))]
        public virtual User RegisterUser { get; set; }

        public Guid ProductRequestId { get; set; }
        [ForeignKey(nameof(ProductRequestId))]
        public virtual ProductRequest ProductRequests { get; set; }

        public virtual ICollection<ExitDetail> ExitDetails { get; set; }

    }

}
