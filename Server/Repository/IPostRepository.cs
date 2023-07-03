using Blog.Server.Models;
using Blog.Shared.Models.DTO.PostDTOS;

namespace Blog.Server.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostDTO>> GetPostsAsync(string? category);
        Task<PostDTO> GetPostByIdAsync(int postId);
        Task AddPostAsync(AddPostDTO postDTO);
        Task UpdatePostAsync(int id,UpdatePostDTO postDTO);
        Task DeletePostAsync(int postId);

    }
}