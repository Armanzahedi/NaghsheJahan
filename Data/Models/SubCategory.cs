using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class SubCategory : IEntity
    {
        public int Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [MaxLength(300)]
        [DisplayName("نام")]
        public string Title { get; set; }

        [MaxLength(300)]
        [DisplayName("تصوبر")]
        public string ImageName { get; set; }
        [DisplayName("توضیح")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("دسته بندی")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
