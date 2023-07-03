using Blog.Server.Models;

namespace Blog.Server.Services.JWT
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(Author author);
    }
}