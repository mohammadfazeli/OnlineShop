using OnlineShop.Entities.AuditableEntity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using OnlineShop.Entities.Entities.Area.WareHouse;
using OnlineShop.Entities.Entities.Orders;

namespace OnlineShop.Entities.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2577
    /// and http://www.dotnettips.info/post/2578
    /// plus http://www.dotnettips.info/post/2559
    /// </summary>
    public class User:IdentityUser<int>, IAuditableEntity
    {
        public User()
        {
            UserUsedPasswords = new HashSet<UserUsedPassword>();
            UserTokens = new HashSet<UserToken>();
            Exits = new HashSet<Exit>();
            Buys = new HashSet<Buy>();
            Orders = new HashSet<Order>();
            RegisterProductRequests = new HashSet<ProductRequest>();
            ApprovedProductRequests = new HashSet<ProductRequest>();
        }

        [StringLength(450)]
        public string FirstName { get; set; }

        [StringLength(450)]
        public string LastName { get; set; }

        [NotMapped]
        public string DisplayName
        {
            get
            {
                var displayName = $"{FirstName} {LastName}";
                return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
            }
        }

        [StringLength(450)]
        public string PhotoFileName { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? LastVisitDateTime { get; set; }

        public bool IsEmailPublic { get; set; }

        public string Location { set; get; }

        public bool IsActive { get; set; } = true;

        public virtual ICollection<UserUsedPassword> UserUsedPasswords { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<Exit> Exits { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [InverseProperty(nameof(ProductRequest.RegisterUser))]
        public virtual ICollection<ProductRequest> RegisterProductRequests { get; set; }

        [InverseProperty(nameof(ProductRequest.ApproveUser))]
        public virtual ICollection<ProductRequest> ApprovedProductRequests { get; set; }
    }
}