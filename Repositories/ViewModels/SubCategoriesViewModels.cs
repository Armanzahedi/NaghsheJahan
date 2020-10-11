using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModels
{
    public class SubCategoriesTableViewModel
    {
        public List<SubCategory> SubCategories { get; set; }
        public PaginationViewModel Pagination { get; set; }
    }
}
