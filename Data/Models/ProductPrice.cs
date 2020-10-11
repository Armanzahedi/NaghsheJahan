using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class ProductPrice : IEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public float Price { get; set; }
        public float MajorPrice { get; set; }
        [Required]
        public bool HasDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }
        public float? MajorPriceAfterDiscount { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
