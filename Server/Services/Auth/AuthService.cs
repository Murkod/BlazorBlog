using Blog.Server.Context;
using Blog.Server.Models;
using Blog.Server.Repository;
using Blog.Server.Services.JWT;
using Blog.Shared.Models.DTO.AuthorDTOS;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Server.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthorRepository context;
        private readonly IJwtService jwtService;

        public AuthService(IAuthorRepository authors,IJwtService jwtService)
        {
            context = authors;
            this.jwtService = jwtService;
        }

        public async Task<string> LoginAuthor(LoginDto loginDto)
        {

            var author = await context.GetAuthorByLogin(loginDto.Username);
            if (author == null) return null;
            var b = await jwtService.GenerateJwtToken(author);
            return b;
        }
    }
}
