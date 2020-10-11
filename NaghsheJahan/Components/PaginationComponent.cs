using Logic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaghsheJahan.Components
{
    public class PaginationComponent : ViewComponent
    {
        private int _pageNumber;
        private int _itemCount;
        private int _availableItemCount;
        private int _take;
        public PaginationComponent(int pageNumber,int itemCount, int take,int availableItemCount)
        {
            _pageNumber = pageNumber;
            _itemCount = itemCount;
            _take = take;
            _availableItemCount = availableItemCount;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pagination = new PaginationViewModel();
            pagination.PageNumber = _pageNumber;
            pagination.ItemCount = _itemCount;

            var numberOfPages = (int)Math.Ceiling(Decimal.Divide(_itemCount, _take));
            pagination.NumberOfPages = numberOfPages;

            pagination.FromItem = _pageNumber * _take - _take + 1;
            pagination.ToItem = _pageNumber * _take - _take + _availableItemCount;

            var pagesList = new List<int>();
            for (int i = 1; i <= numberOfPages; i++)
                pagesList.Add(i);

            var numberOfFivePages = (int)Math.Floor((decimal)_pageNumber / 5);
            var skipPages = numberOfFivePages;
            if (_pageNumber % 5 == 0)
                skipPages -= 1;

            pagesList = pagesList.Skip(skipPages * 5).Take(5).ToList();
            pagination.PagesList = pagesList;
            ViewData["Pagination"] = pagination;
            return View(pagination);
        }
    }
}
