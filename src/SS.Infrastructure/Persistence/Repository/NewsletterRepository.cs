using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class NewsletterRepository: RepositoryBase<Newsletter>, INewsletterRepository
{
    public NewsletterRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Newsletter>> GetAllNewsletterAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(n => n.CreatedOn)
            .ToListAsync();
    }

    public async Task<Newsletter?> GetNewsletterAsync(Guid newsletterId, bool trackChanges)
    {
        return await FindByCondition(n => n.Id == newsletterId, trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateNewsletter(Newsletter newsletter)
    {
        Create(newsletter);
    }

    public void DeleteNewsletter(Newsletter newsletter)
    {
        Delete(newsletter);
    }
}