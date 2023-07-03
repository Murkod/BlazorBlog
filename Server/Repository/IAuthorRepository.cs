using Blog.Server.Models;
using Blog.Shared.Models.DTO.AuthorDTOS;

namespace Blog.Server.Repository
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(AddAuthorDTO authorDTO);
        Task DeleteAuthorAsync(int authorId);
        Task<AuthorDTO> GetAuthorByIdAsync(int authorId);
        Task<Author> GetAuthorByLogin(string login);
        Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();
        Task UpdateAuthorAsync(int authorId, UpdateAuthorDTO updateAuthorDTO);
    }
}