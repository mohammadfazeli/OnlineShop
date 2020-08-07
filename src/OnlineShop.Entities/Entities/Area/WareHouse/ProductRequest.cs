using Microsoft.AspNetCore.Mvc;
using OnlineShop.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Entities.Entities.Area.WareHouse
{
    public class ProductRequest : BaseEntity
    {


        public ProductRequest()
        {
            Exits = new HashSet<Exit>();
        }

        public DateTime? RequsestDate { get; set; }

        public int RegisterUserId { get; set; }
        [ForeignKey(nameof(RegisterUserId))]
        public virtual User RegisterUser { get; set; }

        public int ApproveUserId { get; set; }
        [ForeignKey(nameof(ApproveUserId))]
        public virtual User ApproveUser { get; set; }

        public DateTime? ApproveDate { get; set; }

        public bool Approved { get; set; } = false;

        public virtual ICollection<Exit>  Exits  { get; set; }


    }

}
