using SS.Domain.Blog;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
    Task<Category?> GetCategoryAsync(Guid categoryId, bool trackChanges);
    Void CreateCategory(Category category);
    Void DeleteCategory(Category category);
}