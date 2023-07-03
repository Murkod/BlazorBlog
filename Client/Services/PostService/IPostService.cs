using Blog.Shared.Models.DTO.PostDTOS;

namespace Blog.Client.Services.PostService
{
    public interface IPostService
    {
        Task<PostDTO> GetPostById(int postId);
        Task<List<PostDTO>> GetPosts();
    }
}