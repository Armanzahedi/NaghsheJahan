using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        [MaxLength(300)]
        public string ImageName { get; set; }
        public string Description { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
