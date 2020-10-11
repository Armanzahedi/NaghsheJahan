using Data;
using Data.Models;
using Logic.Extentions;
using Logic.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Services.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{

    public class SubCategoriesRepository : BaseRepository<SubCategory, MyDbContext>
    {
        private readonly MyDbContext _context;
        public SubCategoriesRepository(MyDbContext context) : base(context)
        {
            this._context = context;
        }
        // We can add new methods specific to the artist repository here in the future
        public List<Category> GetCategories()
        {
            return _context.Categories.MyDistinctBy(c => c.Id).ToList();
        }
        public async Task<List<SubCategory>> GetSubCategoriesWithCategory()
        {
            return await _context.SubCategories.Include(s=>s.Category).ToListAsync();
        }

        #region Get data table
        public async Task<SubCategoriesTableViewModel> GetDataTable(int take,int pageNumber)
        {
            int skip = (pageNumber - 1) * take;
            int totalItemCount = _context.SubCategories.Count();
            var subCategories = await _context.SubCategories.Include(s => s.Category).Skip(skip).Take(take).ToListAsync();
            var pageItemCount = subCategories.Count();
            var pagination = Pagination.CreatePaginationData(take, pageNumber, totalItemCount, pageItemCount);

            var subCategoriesTable = new SubCategoriesTableViewModel();
            subCategoriesTable.SubCategories = subCategories;
            subCategoriesTable.Pagination = pagination;
            return subCategoriesTable;
        }
        public async Task<SubCategoriesTableViewModel> GetDataTable(int take, int pageNumber,int categoryId)
        {
            int skip = (pageNumber - 1) * take;
            int totalItemCount = _context.SubCategories.Where(s => s.CategoryId == categoryId).Count();
            var subCategories = await _context.SubCategories.Include(s => s.Category).Where(s=>s.CategoryId == categoryId).Skip(skip).Take(take).ToListAsync();
            var pageItemCount = subCategories.Count();
            var pagination = Pagination.CreatePaginationData(take, pageNumber, totalItemCount, pageItemCount);

            var subCategoriesTable = new SubCategoriesTableViewModel();
            subCategoriesTable.SubCategories = subCategories;
            subCategoriesTable.Pagination = pagination;
            return subCategoriesTable;
        }
        public async Task<SubCategoriesTableViewModel> GetDataTable(int take, int pageNumber,string search)
        {
            int skip = (pageNumber - 1) * take;
            int totalItemCount = _context.SubCategories.Where(s => s.Title.ToLower().Contains(search.ToLower())).Count();
            var subCategories = await _context.SubCategories.Include(s => s.Category).Where(s => s.Title.ToLower().Contains(search.ToLower())).Skip(skip).Take(take).ToListAsync();
            var pageItemCount = subCategories.Count();
            var pagination = Pagination.CreatePaginationData(take, pageNumber, totalItemCount, pageItemCount);

            var subCategoriesTable = new SubCategoriesTableViewModel();
            subCategoriesTable.SubCategories = subCategories;
            subCategoriesTable.Pagination = pagination;
            return subCategoriesTable;
        }
        public async Task<SubCategoriesTableViewModel> GetDataTable(int take, int pageNumber,int categoryId, string search)
        {
            int skip = (pageNumber - 1) * take;
            int totalItemCount = _context.SubCategories.Where(s => s.CategoryId == categoryId && s.Title.ToLower().Contains(search.ToLower())).Count();
            var subCategories = await _context.SubCategories.Include(s => s.Category).Where(s => s.CategoryId == categoryId && s.Title.ToLower().Contains(search.ToLower())).Skip(skip).Take(take).ToListAsync();
            var pageItemCount = subCategories.Count();
            var pagination = Pagination.CreatePaginationData(take, pageNumber, totalItemCount, pageItemCount);

            var subCategoriesTable = new SubCategoriesTableViewModel();
            subCategoriesTable.SubCategories = subCategories;
            subCategoriesTable.Pagination = pagination;
            return subCategoriesTable;
        }
        #endregion
    }
}
