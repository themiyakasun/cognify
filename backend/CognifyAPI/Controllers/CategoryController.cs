using CognifyAPI.Dtos.Category;
using CognifyAPI.Interfaces;
using CognifyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddCategory(CategoryPostDto requestDto)
        {
            var category = new Category
            {
                Title = requestDto.Title,
            };

            var result = await _categoryRepository.CreateAsync(category);

            return Ok(result);
        }
    }
}
