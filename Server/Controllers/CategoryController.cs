using Blog.Server.Models;
using Blog.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas pobierania kategorii.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas pobierania kategorii.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            try
            {
                await _categoryRepository.AddCategoryAsync(category);
                return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas dodawania kategorii.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }

                await _categoryRepository.UpdateCategoryAsync(category);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas aktualizowania kategorii.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryRepository.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas usuwania kategorii.");
            }
        }
    }
}