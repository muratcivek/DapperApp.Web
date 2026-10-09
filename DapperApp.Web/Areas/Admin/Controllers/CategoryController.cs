using DapperApp.Web.DTOs.Categories;
using DapperApp.Web.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DapperApp.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(
        ICategoryService _categoryService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            await _categoryService.CreateAsync(categoryDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateCategoryDto
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };

            return View(updateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryDto);
            }

            var category = await _categoryService.GetByIdAsync(categoryDto.CategoryId);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateAsync(categoryDto);

            return RedirectToAction(nameof(Index));
        }
    }
}