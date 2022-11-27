namespace SS.Application.Interfaces.Persistence.Repository;

public interface IRepositoryManager
{
    IArticleRepository Article { get; }
    ICommentRepository Comment { get; }
    IReactionRepository Reaction { get; }
    Task SaveAsync();
}