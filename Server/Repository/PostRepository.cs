using Blog.Server.Models;
using Blog.Server.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Blog.Shared.Models.DTO.PostDTOS;

namespace Blog.Server.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly NewsContext context;
        private readonly IMapper mapper;

        public PostRepository(NewsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PostDTO>> GetPostsAsync(string? category)
        {
            if (!context.Authors.Any())
            {
                var author1 = new Author
                {
                    AuthorID = 1,
                    Login = "string",
                    PasswordHash = "string",
                    AddTime = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FirstName = "John",
                    LastName = "Doe"
                   
                };
                context.Authors.Add(author1);

                var author2 = new Author
                {
                    AuthorID = 2,
                    Login = "examplelogin2",
                    PasswordHash = "examplepassword2",
                    AddTime = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    FirstName = "Jane",
                    LastName = "Smith"
                };
                context.Authors.Add(author2);

                var category1 = new Category
                {
                    Id = 1,
                    Name = "Category 1"
                };
                context.Categories.Add(category1);

                var category2 = new Category
                {
                    Id = 2,
                    Name = "Category 2"
                };
                context.Categories.Add(category2);

                var post1 = new Post
                {
                    Id = 1,
                    AuthorID = 1,
                    CategoryID = 1,
                    Description = "Example description 1",
                    Title = "Example title 1",
                    Date = DateTime.Now,
                    Content = "Example content 1",
                    Image = "https://www.shutterstock.com/image-vector/sample-red-square-grunge-stamp-260nw-338250266.jpg"
                };
                context.Posts.Add(post1);

                var post2 = new Post
                {
                    Id = 2,
                    AuthorID = 1,
                    CategoryID = 2,
                    Description = "Example description 2",
                    Title = "Example title 2",
                    Date = DateTime.Now,
                    Content = "Example content 2",
                    Image = "https://www.shutterstock.com/image-vector/sample-red-square-grunge-stamp-260nw-338250266.jpg"
                };
                context.Posts.Add(post2);

                context.SaveChanges(); // Zapisujemy zmiany w bazie danych
            }

            return mapper.Map<List<PostDTO>>(context.Posts.Include(x=>x.Category).Where(x=>x.Category.Name.Contains(category)).ToList());
        }

        public async Task<PostDTO> GetPostByIdAsync(int postId)
        {
            var post = await context.Posts.Include(p => p.Author).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == postId);
            var postDTO = mapper.Map<PostDTO>(post);
            return postDTO;
        }

        public async Task AddPostAsync(AddPostDTO addPostDTO)
        {
            var post = new Post
            {
                AuthorID = addPostDTO.AuthorID,
                CategoryID = addPostDTO.CategoryID,
                Description = addPostDTO.Description,
                Title = addPostDTO.Title,
                Date = addPostDTO.Date,
                Content = addPostDTO.Content,
                Image = addPostDTO.Image
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(int id,UpdatePostDTO postEditDTO)
        {
            var post = await context.Posts.FindAsync(id);

            if (post == null)
            {
                // Obsłuż odpowiednio, gdy post o podanym identyfikatorze nie został znaleziony
                throw new Exception("Post not found");
            }
            if (postEditDTO.AuthorID == post.AuthorID)
            {
                post.AuthorID = postEditDTO.AuthorID;
                post.CategoryID = postEditDTO.CategoryID;
                post.Description = postEditDTO.Description;
                post.Title = postEditDTO.Title;
                post.Date = postEditDTO.Date;
                post.Content = postEditDTO.Content;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }
    }
}

