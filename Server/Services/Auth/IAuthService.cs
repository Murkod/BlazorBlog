using Blog.Shared.Models.DTO.AuthorDTOS;

namespace Blog.Server.Services.Auth
{
    public interface IAuthService
    {
        Task<string> LoginAuthor(LoginDto loginDto);
    }
}