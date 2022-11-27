using Microsoft.EntityFrameworkCore;
using SS.Application.Interfaces.Persistence.Repository;
using SS.Domain.Blog;
using SS.Infrastructure.Persistence.Context;

namespace SS.Infrastructure.Persistence.Repository;

internal sealed class CommentRepository : RepositoryBase<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges)
    {
        return await FindAll(trackChanges)
            .OrderBy(c => c.Parent)
            .ToListAsync();
    }

    public async Task<Comment?> GetCommentAsync(Guid id, bool trackChanges)
    {
        return await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
    }

    public void CreateComment(Comment comment)
    {
        Create(comment);
    }

    public void DeleteComment(Comment comment)
    {
        Delete(comment);
    }
}