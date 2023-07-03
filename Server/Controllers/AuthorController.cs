namespace Blog.Server.Controllers
{
    using Blog.Server.Repository;
    using Blog.Shared.Models.DTO;
    using Blog.Shared.Models.DTO.AuthorDTOS;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    [Authorize]
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var authors = await _authorRepository.GetAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas pobierania autorów.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            try
            {
                var author = await _authorRepository.GetAuthorByIdAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas pobierania autora.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorDTO authorDTO)
        {
            try
            {
                await _authorRepository.AddAuthorAsync(authorDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas dodawania autora.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDTO authorDTO)
        {
            try
            {
              

                await _authorRepository.UpdateAuthorAsync(id,authorDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas aktualizowania autora.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                await _authorRepository.DeleteAuthorAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Obsłuż błąd i zwróć odpowiedni status
                return StatusCode(500, "Wystąpił błąd podczas usuwania autora.");
            }
        }
    }

}
