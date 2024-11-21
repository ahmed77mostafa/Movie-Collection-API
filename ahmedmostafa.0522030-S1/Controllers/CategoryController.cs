using ahmedmostafa._0522030_S1.DTOs;
using ahmedmostafa._0522030_S1.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ahmedmostafa._0522030_S1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepo.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            _categoryRepo.AddCategory(categoryDto);
            return Ok();
        }
        [HttpPost("Add Category Movie")]
        public IActionResult AddCategoryMovie(CategoryMovieDto categoryMovieDto)
        {
            _categoryRepo.AddCategoryMovie(categoryMovieDto);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryMovieDto categoryDto)
        {
            _categoryRepo.UpdateCategory(id, categoryDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryRepo.DeleteCategory(id);
            return Ok();
        }
    }
}
