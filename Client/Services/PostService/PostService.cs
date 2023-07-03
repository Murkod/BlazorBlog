using Blog.Shared.Models.DTO.PostDTOS;
using System.Collections.Generic;
using System.Net.Http.Json;

using System.Threading.Tasks;


namespace Blog.Client.Services.PostService
{

    public class PostService : IPostService
    {
        private readonly HttpClient httpClient;

        public PostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PostDTO>> GetPosts()
        {
            return await httpClient.GetFromJsonAsync<List<PostDTO>>("api/post");
        }

        public async Task<PostDTO> GetPostById(int postId)
        {
            return await httpClient.GetFromJsonAsync<PostDTO>($"api/post/{postId}");
        }
    }

}

