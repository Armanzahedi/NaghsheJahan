using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Rating { get; set; }
        public int BaseQuantity { get; set; }
        public bool InStock { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public virtual ProductPrice ProductPrice { get; set; }
        public ICollection<ProductDetial> ProductDetials { get; set; }
    }
}
