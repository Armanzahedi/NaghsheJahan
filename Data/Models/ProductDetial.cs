using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ProductDetial : IEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
