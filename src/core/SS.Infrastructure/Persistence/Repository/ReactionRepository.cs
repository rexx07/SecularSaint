using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class ReactionRepository : RepositoryBase<Reaction>, IReactionRepository
{
    public ReactionRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Reaction>> GetAllReactionsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(r => r.CreatedOn)
            .ToListAsync();
    }

    public async Task<Reaction?> GetReactionAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(r => r.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateReaction(Reaction reaction)
    {
        Create(reaction);
    }

    public void DeleteReaction(Reaction reaction)
    {
        Delete(reaction);
    }
}