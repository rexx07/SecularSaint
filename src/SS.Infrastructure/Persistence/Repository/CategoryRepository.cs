using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.CreatedOn)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryAsync(Guid categoryId, bool trackChanges)
    {
        return await FindByCondition(c => c.Id == categoryId, trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateCategory(Category category)
    {
        Create(category);
    }

    public void DeleteCategory(Category category)
    {
        Delete(category);
    }
}