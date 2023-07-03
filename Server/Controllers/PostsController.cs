using Blog.Shared;
using Microsoft.AspNetCore.Mvc;
using Blog.Server.Context;
using Blog.Server.Models;
using Blog.Server.Repository;
using Blog.Shared.Models.DTO.PostDTOS;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Server.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class PostsController : ControllerBase
    {
      
        private readonly ILogger<PostsController> _logger;
        
        private readonly IPostRepository _postRepository;

        public PostsController(ILogger<PostsController> logger,IPostRepository newsRepository)
        {
            _logger = logger;
            _postRepository = newsRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts(string? category = "")
        {
            try
            {
                var posts = await _postRepository.GetPostsAsync(category);
                return Ok(posts.ToList());
            }
            catch (Exception ex)
            {
                // Obsługa błędów i zwracanie odpowiedniego statusu HTTP
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                // Obsługa błędów i zwracanie odpowiedniego statusu HTTP
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] AddPostDTO postDTO)
        {
            postDTO.AuthorID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            try
            {
                await _postRepository.AddPostAsync(postDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                // Obsługa błędów i zwracanie odpowiedniego statusu HTTP
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] UpdatePostDTO postDTO)
        {
            var authorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            postDTO.AuthorID=authorId; 
            try
            {
                
                await _postRepository.UpdatePostAsync(id,postDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                // Obsługa błędów i zwracanie odpowiedniego statusu HTTP
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postRepository.DeletePostAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Obsługa błędów i zwracanie odpowiedniego statusu HTTP
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}