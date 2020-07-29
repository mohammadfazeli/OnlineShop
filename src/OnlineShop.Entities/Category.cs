using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using OnlineShop.Entities.AuditableEntity;

namespace OnlineShop.Entities
{
    public class Category : IAuditableEntity
    {

        public Category()
        {
            Products = new HashSet<Product>();
            //Id = Guid.NewGuid();
        }

        [Key]
        //public Guid Id { get; set; }
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}