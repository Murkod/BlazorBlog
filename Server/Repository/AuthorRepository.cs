using AutoMapper;
using Blog.Server.Context;
using Blog.Server.Models;
using Blog.Shared.Models.DTO.AuthorDTOS;
using Microsoft.EntityFrameworkCore;

namespace Blog.Server.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly NewsContext context;
        private readonly IMapper mapper;

        public AuthorRepository(NewsContext dbContext, IMapper mapper)
        {
            this.context = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            var authors = await context.Authors.ToListAsync();
            var authorDTOs = mapper.Map<List<AuthorDTO>>(authors);
            return authorDTOs;
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int authorId)
        {
            var author = await context.Authors.FirstOrDefaultAsync(a => a.AuthorID == authorId);
            var authorDTO = mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public async Task AddAuthorAsync(AddAuthorDTO authorDTO)
        {
            var author = new Author
            {
                Login = authorDTO.Login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(authorDTO.Password),
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                AddTime = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();

            context.Authors.Add(author);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAuthorAsync(int authorId, UpdateAuthorDTO updateAuthorDTO)
        {
            var author = await context.Authors.FindAsync(authorId);

            if (author != null)
            {
                if (!string.IsNullOrEmpty(updateAuthorDTO.FirstName))
                {
                    author.FirstName = updateAuthorDTO.FirstName;
                }

                if (!string.IsNullOrEmpty(updateAuthorDTO.LastName))
                {
                    author.LastName = updateAuthorDTO.LastName;
                }

                if (!string.IsNullOrEmpty(updateAuthorDTO.Password))
                {
                    author.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateAuthorDTO.Password);
                }

                author.UpdatedAt = DateTime.Now;

                await context.SaveChangesAsync();
            }
        }




        public async Task DeleteAuthorAsync(int authorId)
        {
            var author = await context.Authors.FirstOrDefaultAsync(a => a.AuthorID == authorId);
            if (author != null)
            {
                context.Authors.Remove(author);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Author> GetAuthorByLogin(string login)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Login == login);
           
            return author;
        }
    }
}
