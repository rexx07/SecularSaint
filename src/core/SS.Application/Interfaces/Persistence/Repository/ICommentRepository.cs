using SS.Domain.Blog;

namespace SS.Application.Interfaces.Persistence.Repository;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllCommentsAsync(bool trackChanges);
    Task<Comment?> GetCommentAsync(Guid id, bool trackChanges);
    void CreateComment(Comment comment);
    void DeleteComment(Comment comment);
}