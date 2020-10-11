using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories.Repositories;
using Data;
using Data.Models;
using Logic.ViewModels;
using System.IO;
using System.Net.Http.Headers;

namespace NaghsheJahan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly SubCategoriesRepository _repository;

        public SubCategoriesController(SubCategoriesRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin/SubCategories
        public ViewResult Index()
        {
            TempData["UploadedImage"] = null; // In case we return from cancelled create or edit
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "Id", "Title");
            return View();
        }
        public async Task<PartialViewResult> DataTable(int? categoryId, string search = "", int pageNumber = 1, int take = 5)
        {
            var data = new SubCategoriesTableViewModel();

            #region Get Subcategories
            if (categoryId != null && !string.IsNullOrEmpty(search))
                data = await _repository.GetDataTable(take, pageNumber, categoryId.Value, search);
            else if (categoryId != null)
                data = await _repository.GetDataTable(take, pageNumber, categoryId.Value);
            else if (!string.IsNullOrEmpty(search))
                data = await _repository.GetDataTable(take, pageNumber, search);
            else
                data = await _repository.GetDataTable(take, pageNumber);
            #endregion

            return PartialView(data);
        }

        // GET: Admin/SubCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "Id", "Title");
            return View();
        }

        // POST: Admin/SubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                subCategory.Created_at = DateTime.Now;
                subCategory.Updated_at = DateTime.Now;
                if(TempData["UploadedImage"] != null)
                    subCategory.ImageName = TempData["UploadedImage"].ToString();

                await _repository.Add(subCategory);
                TempData["UploadedImage"] = null;
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "Id", "Title", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: Admin/SubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _repository.Get(id.Value);
            if (subCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "Id", "Title", subCategory.CategoryId);
            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.Update(subCategory);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_repository.GetCategories(), "Id", "Title", subCategory.CategoryId);
            return View(subCategory);
        }

        // GET: Admin/SubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCategory = await _repository.Get(id.Value);
            if (subCategory == null)
            {
                return NotFound();
            }

            return View(subCategory);
        }

        // POST: Admin/SubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult FileUpload()
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var file in files)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "SubCategories", imageName);
                using var stream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(stream);
                TempData["UploadedImage"] = imageName;
            }
            return Ok();
        }

        private bool SubCategoryExists(int id)
        {
            return _repository.EntityExist(id);
        }
    }
}
