using Logic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Extentions
{
    public static class Pagination
    {
        public static PaginationViewModel CreatePaginationData(int take, int pageNumber, int totalItemCount, int pageItemCount)
        {
            var pagination = new PaginationViewModel();
            pagination.ItemCount = totalItemCount;

            pagination.PageNumber = pageNumber;
            var numberOfPages = (int)Math.Ceiling(Decimal.Divide(totalItemCount, take));
            pagination.NumberOfPages = numberOfPages;

            pagination.FromItem = pageNumber * take - take + 1;
            pagination.ToItem = pageNumber * take - take + pageItemCount;

            var pagesList = new List<int>();
            for (int i = 1; i <= numberOfPages; i++)
                pagesList.Add(i);

            var numberOfFivePages = (int)Math.Floor((decimal)pageNumber / 5);
            if (pageNumber % 5 == 0)
                numberOfFivePages -= 1;
            var skipPages = numberOfFivePages * 5;
            pagesList = pagesList.Skip(skipPages).Take(5).ToList();
            pagination.PagesList = pagesList;
            return pagination;
        }
    }
}
