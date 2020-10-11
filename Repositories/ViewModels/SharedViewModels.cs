using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ViewModels
{
    public class PaginationViewModel
    {
        public int PageNumber { get; set; }
        public int NumberOfPages { get; set; }
        public int ItemCount { get; set; }
        public int FromItem { get; set; }
        public int ToItem { get; set; }
        public List<int> PagesList { get; set; }

    }
}
