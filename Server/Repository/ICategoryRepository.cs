using Blog.Server.Models;

namespace Blog.Server.Repository
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task UpdateCategoryAsync(Category category);
    }
}