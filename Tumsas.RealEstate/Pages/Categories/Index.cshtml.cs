using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tumsas.RealEstate.Business.Abstract;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;

namespace Tumsas.RealEstate.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public CategoryDto Category { get; set; }

        public List<SelectListItem> ParentLookupList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(" - ", "")
        };

        private ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async void OnGet()
        {
            ParentLookupList.AddRange(
                _categoryService.GetList().Data.Select(t => new SelectListItem(t.Title, t.Id.ToString())).ToList()
                );

            await Task.CompletedTask;
        }

        public IActionResult OnGetCategory(int id)
        {
            var response = _categoryService.GetById(id);

            return new JsonResult(response);
        }

        public IActionResult OnGetCategories()
        {
            var response = _categoryService.GetList();

            return new JsonResult(response);
        }

        public IActionResult OnPost(CategoryDto category)
        {
            var response = _categoryService.Add(category);

            return new JsonResult(response);
        }

        public IActionResult OnPut(CategoryDto category)
        {
            var response = _categoryService.UpdateById(category.Id, category);

            return new JsonResult(response);
        }

        public IActionResult OnDelete(int id)
        {
            var response = _categoryService.DeleteById(id);

            return new JsonResult(response);
        }
    }
}