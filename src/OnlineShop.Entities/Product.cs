using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Entities.AuditableEntity;

namespace OnlineShop.Entities
{
    public class Product : IAuditableEntity
    {

        public Product()
        {
            //Id = Guid.NewGuid();
        }

        [Key]
        //public Guid Id { get; set; }
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public int CategoryId { get; set; }
    }
}